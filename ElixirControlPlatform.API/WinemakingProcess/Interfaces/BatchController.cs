using System.Net.Mime;
using ElixirControlPlatform.API.Profiles.Domain.Repositories;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
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
public class BatchController(IBatchQueryService batchQueryService, IBatchCommandService batchCommandService, IProfileRepository profileRepository): ControllerBase
{
    
    // GET BATCH BY ID ------------------------------------------------- ----
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
    
    // POST -----------------------------------------------------
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Batch",
        Description = "Create a Batch",
        OperationId = "CreateTutorial"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Batch was successfully created", typeof(BatchResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Batch was not created")]
    public async Task<IActionResult> CreateBatch([FromBody] CreateBatchResource resource, [FromQuery] Guid profileId )
    {
        
        var profile = await profileRepository.GetProfileByIdAsync(profileId);
        
        //Mensaje perosnalizado
        if (profile is null) return BadRequest("Profile not found");
        
        var createBatchCommand = CreateBatchCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var batch = await batchCommandService.Handle(createBatchCommand, profile.Id);
        
        if (batch is null) return BadRequest();
        
        var batchResource = BatchResourceFromEntityAssembler.ToResourceFromEntity(batch);
        
        return CreatedAtAction(nameof(GetBatchById), new {batchId = batch.Id}, batchResource);
    }
    
    // GET ALL BATCHES -----------------------------------------------------
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
    
    // DELETE BATCH -----------------------------------------------------
    [HttpDelete("{batchId:int}")]
    [SwaggerOperation(
        Summary = "Delete a Batch",
        Description = "Delete a Batch",
        OperationId = "DeleteBatch"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The Batch was successfully deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Batch was not found")]
    public async Task<IActionResult> DeleteBatch(int batchId)
    {
        var deleteBatchCommand = new DeleteBatchCommand(batchId);
        
        var result = await batchCommandService.Handle(deleteBatchCommand);
        
        if (!result)
        {
            return NotFound( new { title = "Delete Product", message = "The product does not exist" });
        }
        
        return NoContent();
    }
    
    
   
}