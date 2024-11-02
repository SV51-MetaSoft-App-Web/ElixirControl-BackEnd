using System.Net.Mime;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Services;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST;


[ApiController]
[Route("api/v1/winemakingProcess")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Winemaking Process by batch Endpoints")]
public class WinemakingProcessByBatchController(IBatchQueryService batchQueryService, IBatchCommandService batchCommandService): ControllerBase
{
    
    [HttpGet("{batchId:int}")]
    [SwaggerOperation(
        Summary = "Get a Batch by id",
        Description = "Get a Batch by id",
        OperationId = "GetBatchById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Batch was successfully retrieved", typeof(BatchResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Batch was not found")]
    public async Task<IActionResult> GetBatchById(int batchId)
    {
        var getBatchByIdQuery = new GetBatchByIdQuery(batchId);
        var batch = await batchQueryService.Handle(getBatchByIdQuery);
        if (batch is null) return NotFound();
        var batchResource = BatchResourceFromEntityAssembler.ToResourceFromEntity(batch);
        return Ok(batchResource);
    }
    
    //AddFermentationToBatchCommand
    [HttpPost("{batchId:int}/fermentation")]
    [SwaggerOperation(
        Summary = "Add a Fermentation to a Batch",
        Description = "Add a Fermentation to a Batch",
        OperationId = "AddFermentationToBatch"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Fermentation was successfully added to the Batch", typeof(BatchResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Fermentation was not added to the Batch")]
    public async Task<IActionResult> AddFermentationToBatch([FromBody] AddFermentationToBatchResource resource, int batchId)
    {
        var addFermentationToBatchCommand = AddFermentationToBatchCommandFromResourceAssembler.ToCommandFromResource(resource, batchId);
        var batch = await batchCommandService.Handle(addFermentationToBatchCommand);
        if (batch is null) return BadRequest();
        var batchResource = BatchResourceFromEntityAssembler.ToResourceFromEntity(batch);
        return CreatedAtAction(nameof(GetBatchById), new {batchId = batch.Id}, batchResource);
    }
    
    //AddClarificationToBatchCommand
    [HttpPost("{batchId:int}/clarification")]
    [SwaggerOperation(
        Summary = "Add a Clarification to a Batch",
        Description = "Add a Clarification to a Batch",
        OperationId = "AddClarificationToBatch"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Clarification was successfully added to the Batch", typeof(BatchResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Clarification was not added to the Batch")]
    public async Task<IActionResult> AddClarificationToBatch([FromBody] AddClarificationToBatchResource resource, int batchId)
    {
        var addClarificationToBatchCommand = AddClarificationToBatchCommandFromResourceAssembler.ToCommandFromResource(resource, batchId);
        var batch = await batchCommandService.Handle(addClarificationToBatchCommand);
        if (batch is null) return BadRequest();
        var batchResource = BatchResourceFromEntityAssembler.ToResourceFromEntity(batch);
        return CreatedAtAction(nameof(GetBatchById), new {batchId = batch.Id}, batchResource);
    }
}