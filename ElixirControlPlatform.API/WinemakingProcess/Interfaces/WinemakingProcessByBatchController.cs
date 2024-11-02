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
    
    //================================================= BATCH - FERMENTATION ==========================================
    
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
        var fermentation = await batchQueryService.Handle(new GetFermentationByBatchIdQuery(batchId));
        if (fermentation is null) return NotFound();
        var fermentationResource = FermentationResourceFromEntityAssembler.ToResourceFromEntity(fermentation);
        return Ok(fermentationResource);
    }
   
    
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
    
    //============================================== END BATCH - FERMENTATION =========================================
        
    
    
    
    //================================================= BATCH - CLARIFICATION ==========================================
    
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
        var clarification = await batchQueryService.Handle(new GetClarificationByBatchIdQuery(batchId));
        if (clarification is null) return NotFound();
        var clarificationResource = ClarificationResourceFromEntityAssembler.ToResourceFromEntity(clarification);
        return Ok(clarificationResource);
    }
    
    
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
    
    //============================================== END BATCH - CLARIFICATION =========================================
    
    [HttpGet("batch/{batchId:int}/pressing")]
    [SwaggerOperation(
        Summary = "Get a Pressing by Batch",
        Description = "Get a Pressing by Batch",
        OperationId = "GetPressingByBatch"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Pressing was successfully retrieved", typeof(PressingResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Pressing was not found")]
    public async Task<IActionResult> GetPressingByBatch(int batchId)
    {
        var pressing = await batchQueryService.Handle(new GetPressingByBatchIdQuery(batchId));
        if (pressing is null) return NotFound();
        var pressingResource = PressingResourceFromEntityAssembler.ToResourceFromEntity(pressing);
        return Ok(pressingResource);
    }
    
    [HttpPost("{batchId:int}/pressing")]
    [SwaggerOperation(
        Summary = "Add a Pressing to a Batch",
        Description = "Add a Pressing to a Batch",
        OperationId = "AddPressingToBatch"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Pressing was successfully added to the Batch", typeof(BatchResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Pressing was not added to the Batch")]
    public async Task<IActionResult> AddPressingToBatch([FromBody] AddPressingToBatchResource resource, int batchId)
    {
        var addPressingToBatchCommand = AddPressingToBatchCommandFromResourceAssembler.ToCommandFromResource(resource, batchId);
        var batch = await batchCommandService.Handle(addPressingToBatchCommand);
        if (batch is null) return BadRequest();
        var batchResource = BatchResourceFromEntityAssembler.ToResourceFromEntity(batch);
        return CreatedAtAction(nameof(GetPressingByBatch), new {batchId = batch.Id}, batchResource);
    }
    
}