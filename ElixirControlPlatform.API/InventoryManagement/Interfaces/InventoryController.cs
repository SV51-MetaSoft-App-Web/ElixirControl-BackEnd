using System.Net.Mime;
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
public class InventoryController : ControllerBase
{
    private readonly IInventoryQueryService inventoryQueryService;
    private readonly IInventoryCommandService inventoryCommandService;

    public InventoryController(IInventoryQueryService inventoryQueryService, IInventoryCommandService inventoryCommandService)
    {
        this.inventoryQueryService = inventoryQueryService;
        this.inventoryCommandService = inventoryCommandService;
    }

    
    [HttpGet("{inventoryId:int}")]
    [SwaggerOperation(
        Summary = "Get an Inventory by id",
        Description = "Get an Inventory by id",
        OperationId = "GetInventoryById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventory was successfully retrieved", typeof(InventoryResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The inventory was not found")]
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
        Description = "Create an Inventory",
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
}