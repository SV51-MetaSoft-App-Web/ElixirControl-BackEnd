using System.Net.Mime;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
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

public class OrderController(IOrderQueryService orderQueryService, IOrderCommandService orderCommandService): ControllerBase

{
    [HttpGet("{orderId:int}")]
    [SwaggerOperation(
        Summary = "Get order by ID",
        Description = "Get order by ID",
        OperationId = "GetOrderById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The tutorial was successfully retrieved", typeof(OrderResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The order was not found")]

    public async Task<IActionResult> GetOrderById(int orderId)
    {
        var getOrderByIdQuery = new GetOrderByIdQuery(orderId);
        var order = await orderQueryService.Handle(getOrderByIdQuery);
        if (order is null) return NotFound();
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
        return Ok(orderResource);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create new order", Description = "Create new order", OperationId = "CreateOrder")]
    [SwaggerResponse(StatusCodes.Status201Created, "The order was successfully created", typeof(OrderResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The order was not found")]

    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderResource resource)
    {
        var createOrderCommand = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var order = await orderCommandService.Handle(createOrderCommand);
        
        if (order is null) return BadRequest();
        
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
        
        return CreatedAtAction(nameof(GetOrderById), new { orderId = order.Id }, orderResource);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get orders", Description = "Get orders", OperationId = "GetOrders")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Orders were successfully retrieved",
        typeof(IEnumerable<OrderResource>))]

    public async Task<IActionResult> GetOrders()
    {
        var getAllOrdersQuery = new GetAllOrdersQuery();
        var orders = await orderQueryService.Handle(getAllOrdersQuery);
        var orderResources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(orderResources);
        
    }
    
}