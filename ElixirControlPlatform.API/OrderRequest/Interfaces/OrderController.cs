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
[SwaggerTag("Available Order Requests")]

public class OrderRequestController(IOrderRequestQueryService orderRequestQueryService, IOrderRequestCommandService orderRequestCommandService): ControllerBase

{
    [HttpGet("{orderId:int}")]
    [SwaggerOperation(
        Summary = "Get order requests by ID",
        Description = "Get order requests by ID",
        OperationId = "GetOrderRequestsById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The tutorial was successfully retrieved", typeof(OrderRequestResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The order was not found")]

    public async Task<IActionResult> GetOrderRequestById(int orderId)
    {
        var getOrderRequestByIdQuery = new GetOrderRequestByIdQuery(orderId);
        var orderRequests = await orderRequestQueryService.Handle(getOrderRequestByIdQuery);
        if (orderRequests is null) return NotFound();
        var orderResource = OrderRequestResourceFromEntityAssembler.ToResourceFromEntity(orderRequests);
        return Ok(orderResource);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create new order", Description = "Create new order", OperationId = "CreateOrder")]
    [SwaggerResponse(StatusCodes.Status201Created, "The order was successfully created", typeof(OrderRequestResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The order was not found")]

    public async Task<IActionResult> CreateOrderRequest([FromBody] CreateOrderRequestResource requestResource)
    {
        var createOrderRequestCommand = CreateOrderRequestCommandFromResourceAssembler.ToCommandFromResource(requestResource);
        var orderRequests = await orderRequestCommandService.Handle(createOrderRequestCommand);
        
        if (orderRequests is null) return BadRequest();
        
        var orderResource = OrderRequestResourceFromEntityAssembler.ToResourceFromEntity(orderRequests);
        
        return CreatedAtAction(nameof(GetOrderRequestById), new { orderId = orderRequests.Id }, orderResource);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get orders", Description = "Get orders", OperationId = "GetOrders")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Orders were successfully retrieved",
        typeof(IEnumerable<OrderRequestResource>))]

    public async Task<IActionResult> GetOrdersRequest()
    {
        var getAllOrdersQuery = new GetAllOrdersRequestQuery();
        var ordersRequests = await orderRequestQueryService.Handle(getAllOrdersQuery);
        var orderRequestResources = ordersRequests.Select(OrderRequestResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(orderRequestResources);
        
    }
    
}