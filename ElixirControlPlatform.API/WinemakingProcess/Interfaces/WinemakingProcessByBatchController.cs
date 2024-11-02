using System.Net.Mime;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;
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
    
    [HttpGet("batch/{batchId:int}/fermentation")]
    [SwaggerOperation(
        Summary = "Get a Fermentation by Batch",
        Description = "Get a Fermentation by Batch",
        OperationId = "GetFermentationByBatch"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Fermentation was successfully retrieved", typeof(FermentationResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Fermentation was not found")]
    public async Task<IActionResult> GetFermentationByBatch(int batchId)
    {
        var getBatchByIdQuery = new GetBatchByIdQuery(batchId);
        var batch = await batchQueryService.Handle(getBatchByIdQuery);
        if (batch.Fermentation is null) return NotFound();
        return Ok(batch.Fermentation);
    }
    
    [HttpGet("batch/{batchId:int}/clarification")]
    [SwaggerOperation(
        Summary = "Get a Clarification by Batch",
        Description = "Get a Clarification by Batch",
        OperationId = "GetClarificationByBatch"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Clarification was successfully retrieved", typeof(ClarificationResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Clarification was not found")]
    public async Task<IActionResult> GetClarificationByBatch(int batchId)
    {
        var getBatchByIdQuery = new GetBatchByIdQuery(batchId);
        var batch = await batchQueryService.Handle(getBatchByIdQuery);
        if (batch.Clarification is null) return NotFound();
        return Ok(batch.Clarification);
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
        return CreatedAtAction(nameof(GetFermentationByBatch), new {batchId = batch.Id}, batchResource);
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
        return CreatedAtAction(nameof(GetClarificationByBatch), new {batchId = batch.Id}, batchResource);
    }
}