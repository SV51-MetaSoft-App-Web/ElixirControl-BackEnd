using System.Net.Mime;
using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.InventoryManagement.Domain.Services;
using ElixirControlPlatform.API.InventoryManagement.Interfaces.REST.Resources;
using ElixirControlPlatform.API.InventoryManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirControlPlatform.API.InventoryManagement.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Inventory Endpoints")]
public class InventoryController(IInventoryQueryService inventoryQueryService, IInventoryCommandService inventoryCommandService) : ControllerBase
{
    [HttpGet("{inventoryId:int}")]
    [SwaggerOperation(
        Summary = "Get an Inventory by id",
        Description = "Get an Inventory by id",
        OperationId = "GetInventoryById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Inventory was successfully retrieved", typeof(InventoryResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Inventory was not found")]
    public async Task<IActionResult> GetInventoryById(int inventoryId)
    {
        var getInventoryByIdQuery = new GetInventoryByIdQuery(inventoryId);
        var inventory = await inventoryQueryService.Handle(getInventoryByIdQuery);
        if (inventory is null) return NotFound();
        
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return Ok(inventoryResource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create an Inventory",
        Description = "Create a new Inventory",
        OperationId = "CreateInventory"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Inventory was successfully created", typeof(InventoryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Inventory was not created")]
    public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryResource resource)
    {
        var createInventoryCommand = CreateInventoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var inventory = await inventoryCommandService.Handle(createInventoryCommand);
        
        if (inventory is null) return BadRequest();
        
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        
        return CreatedAtAction(nameof(GetInventoryById), new { inventoryId = inventory.Id }, inventoryResource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all Inventories",
        Description = "Get all Inventories",
        OperationId = "GetAllInventories"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Inventories were successfully retrieved", typeof(IEnumerable<InventoryResource>))]
    public async Task<IActionResult> GetAllInventories()
    {
        var getAllInventoriesQuery = new GetAllInventoriesQuery();
        var inventories = await inventoryQueryService.Handle(getAllInventoriesQuery);
        var inventoryResources = inventories.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(inventoryResources);
    }
    [HttpGet("search")]
    [SwaggerOperation(
        Summary = "Search Inventories",
        Description = "Search for Inventories by name, unit, or type",
        OperationId = "SearchInventories"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Inventories were successfully retrieved", typeof(IEnumerable<InventoryResource>))]
    public async Task<IActionResult> SearchInventories([FromQuery] string? name, [FromQuery] string? unit, [FromQuery] string? type)
    {
        var searchQuery = new GetInventoriesByFilterQuery(name, unit, type);
        
        var inventories = await inventoryQueryService.Handle(searchQuery);
        
        var inventoryResources = inventories.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(inventoryResources);
    }
    [HttpPut("{inventoryId:int}")]
    [SwaggerOperation(
        Summary = "Update an Inventory",
        Description = "Update an existing Inventory",
        OperationId = "UpdateInventory"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Inventory was successfully updated", typeof(InventoryResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Inventory was not found")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
    public async Task<IActionResult> UpdateInventory(int inventoryId, [FromBody] UpdateInventoryResource resource)
    {
        // Validaciones
        if (string.IsNullOrWhiteSpace(resource.Name) || 
            string.IsNullOrWhiteSpace(resource.Type) || 
            string.IsNullOrWhiteSpace(resource.Unit) || 
            string.IsNullOrWhiteSpace(resource.Supplier) || 
            resource.CostPerUnit <= 0 || 
            resource.Quantity <= 0 || 
            resource.Expiration <= DateTime.UtcNow)
        {
            return BadRequest("Invalid input data.");
        }

        var updateCommand = new UpdateInventoryCommand(
            inventoryId,
            resource.Name,
            resource.Type,
            resource.Unit,
            resource.Expiration,
            resource.Supplier,
            resource.CostPerUnit,
            resource.Quantity
        );

        var updatedInventory = await inventoryCommandService.Handle(updateCommand);

        if (updatedInventory == null) return NotFound();
        
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(updatedInventory);
        
        return Ok(inventoryResource);
    }
}