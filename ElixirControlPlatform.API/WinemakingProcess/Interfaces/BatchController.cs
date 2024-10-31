using System.Net.Mime;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Services;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Batch Endpoints")]
public class BatchController(IBatchQueryService batchQueryService, IBatchCommandService batchCommandService): ControllerBase
{
    
    
    [HttpGet("{batchId:int}")]
    [SwaggerOperation(
        Summary = "Get a Batch by id",
        Description = "Get a Batch by id",
        OperationId = "GetBatchById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The tutorial was successfully retrieved", typeof(BatchResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The tutorial was not found")]
    public async Task<IActionResult> GetBatchById(int batchId)
    {
        var getBatchByIdQuery = new GetBatchByIdQuery(batchId);
        var batch = await batchQueryService.Handle(getBatchByIdQuery);
        if (batch is null) return NotFound();
        var batchResource = BatchResourceFromEntityAssembler.ToResourceFromEntity(batch);
        return Ok(batchResource);
    }
    
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Batch",
        Description = "Create a Batch",
        OperationId = "CreateTutorial"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Batch was successfully created", typeof(BatchResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Batch was not created")]
    public async Task<IActionResult> CreateBatch([FromBody] CreateBatchResource resource)
    {
        var createBatchCommand = CreateBatchCommandFromResourceAssembler.ToCommandFromResource(resource);
        var batch = await batchCommandService.Handle(createBatchCommand);
        
        if (batch is null) return BadRequest();
        
        var batchResource = BatchResourceFromEntityAssembler.ToResourceFromEntity(batch);
        
        return CreatedAtAction(nameof(GetBatchById), new {batchId = batch.Id}, batchResource);
    }
    
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all Batches",
        Description = "Get all Batches",
        OperationId = "GetAllBatches"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Batches were successfully retrieved", typeof(IEnumerable<BatchResource>))]
    public async Task<IActionResult> GetAllBatches()
    {
        var getAllBatchesQuery = new GetAllBatchesQuery();
        var batches = await batchQueryService.Handle(getAllBatchesQuery);
        var batchResources = batches.Select(BatchResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(batchResources);
    }
    
    
    
    
    
}