using System.Net.Mime;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.OrderManagement.Domain.Services;
using ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Resources;
using ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirControlPlatform.API.OrderManagement.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Orders")]
[SwaggerTag("Available order endpoints")]
public class OrdersController(IOrderCommandService orderCommandService, IOrderQueryService orderQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create order",
        Description = "Create a new order",
        OperationId = "CreateOrder"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The order was created", typeof(OrderResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The order could not be created")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderResource resource)
    {
        var createOrderCommand = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await orderCommandService.Handle(createOrderCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetOrderById), new {id = result.Id},
            OrderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get order by id",
        Description = "Get an order by its id",
        OperationId = "GetOrderById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The order was found", typeof(OrderResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The order was not found")]
    public async Task<ActionResult> GetOrderById( int id)
    {
        var getOrderByIdQuery = new GetOrderByIdQuery(id);
        var result = await orderQueryService.Handle(getOrderByIdQuery);
        if (result is null) return NotFound();
        var resource = OrderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all Orders",
        Description = "Get all Orders",
        OperationId = "GetAllOrders"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The orders were successfully retrieved", typeof(IEnumerable<OrderResource>))]
    public async Task<IActionResult> GetAllOrders()
    {
        var getAllOrdersQuery = new GetAllOrdersQuery();
        var orders = await orderQueryService.Handle(getAllOrdersQuery);
        var orderResources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(orderResources);
    }
}