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
[Tags("Order Requests")]
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
    
    [HttpPut("{id}/status")]
    [SwaggerOperation(
        Summary = "Update order requests status",
        Description = "Update order requests status",
        OperationId = "UpdateOrderRequestsStatusById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The order requests status was updated")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The order requests status  could not be updated")]
    public async Task<IActionResult> UpdateOrderRequests(int id, [FromBody] UpdateOrderRequestsStatusByIdResource statusByIdResource)
    {
        var updateOrderRequestsCommand = UpdateOrderRequestsCommandFromResourceAssembler.ToCommandFromResource(id, statusByIdResource);
        var result = await orderRequestsCommandService.Handle(updateOrderRequestsCommand);
        if (result is null) return BadRequest();
        return Ok(OrderRequestsResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete order requests",
        Description = "Delete order requests",
        OperationId = "DeleteOrderRequests"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The order requests was deleted")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The order requests could not be deleted")]
    public async Task<IActionResult> DeleteOrderRequests(int id)
    {
        var deleteOrderRequestsCommand = new DeleteOrderRequestsCommand(id);
        var result = await orderRequestsCommandService.Handle(deleteOrderRequestsCommand);
        if (result is null) return BadRequest();
        return Ok(OrderRequestsResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    /***/
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update order requests",
        Description = "Update order requests",
        OperationId = "UpdateOrderRequests"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The order requests was updated")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The order requests could not be updated")]
    public async Task<IActionResult> UpdateOrderRequests(int id, [FromBody] UpdateOrderRequestsByIdResource updateOrderRequestsByIdResource)
    {
        var updateOrderRequestsByIdCommand = UpdateOrderRequestsByIdCommandFromResourceAssembler.ToCommandFromResource(id, updateOrderRequestsByIdResource);
        var result = await orderRequestsCommandService.Handle(updateOrderRequestsByIdCommand);
        if (result is null) return BadRequest();
        return Ok(OrderRequestsResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
}