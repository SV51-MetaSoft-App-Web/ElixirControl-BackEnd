using System.Net.Mime;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Queries;
using ElixirControlPlatform.API.OrderRequest.Domain.Services;
using ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Resources;
using ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirControlPlatform.API.OrderRequest.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Order Requests Endpoints")]

public class OrderRequestsController(IOrderRequestsQueryService orderRequestsQueryService, IOrderRequestsCommandService orderRequestsCommandService): ControllerBase

{
    [HttpGet("{orderRequestsId:int}")]
    [SwaggerOperation(
        Summary = "Get order requests by ID",
        Description = "Get order requests by ID",
        OperationId = "GetOrderRequestsById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The tutorial was successfully retrieved", typeof(OrderRequestsResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The order was not found")]

    public async Task<IActionResult> GetOrderRequestsById(int orderRequestsId)
    {
        var getOrderRequestsByIdQuery = new GetOrderRequestsByIdQuery(orderRequestsId);
        var orderRequests = await orderRequestsQueryService.Handle(getOrderRequestsByIdQuery);
        if (orderRequests is null) return NotFound();
        var orderRequestsResource = OrderRequestsResourceFromEntityAssembler.ToResourceFromEntity(orderRequests);
        return Ok(orderRequestsResource);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a Order Requests", Description = "Create a Order Requests", OperationId = "CreateTutorial")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Order Requests was successfully created", typeof(OrderRequestsResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The order was not created")]

    public async Task<IActionResult> CreateOrderRequests([FromBody] CreateOrderRequestsResource resource)
    {
        var createOrderRequestsCommand = CreateOrderRequestsCommandFromResourceAssembler.ToCommandFromResource(resource);
        var orderRequests = await orderRequestsCommandService.Handle(createOrderRequestsCommand);
        
        if (orderRequests is null) return BadRequest();
        
        var orderRequestsResource = OrderRequestsResourceFromEntityAssembler.ToResourceFromEntity(orderRequests);
        
        return CreatedAtAction(nameof(GetOrderRequestsById), new { orderRequestsId = orderRequests.Id }, orderRequestsResource);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get orders", Description = "Get orders", OperationId = "GetOrders")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Orders were successfully retrieved",
        typeof(IEnumerable<OrderRequestsResource>))]

    public async Task<IActionResult> GetOrdersRequests()
    {
        var getAllOrdersQuery = new GetAllOrdersRequestsQuery();
        var ordersRequests = await orderRequestsQueryService.Handle(getAllOrdersQuery);
        var orderRequestsResources = ordersRequests.Select(OrderRequestsResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(orderRequestsResources);
        
    }
    
}