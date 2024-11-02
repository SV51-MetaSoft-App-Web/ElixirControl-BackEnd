using ElixirControlPlatform.API.Shared.Domain.Repositories;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.ValueObjects;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Services;

namespace ElixirControlPlatform.API.WinemakingProcess.Application.Internal.CommandServices;

public class BatchCommandService(IBatchRepository batchRepository, IUnitOfWOrk unitOfWork) : IBatchCommandService
{
    private IBatchCommandService _batchCommandServiceImplementation;

    public async Task<Batch?> Handle(CreateBatchCommand command)
    {
        var batch = new Batch(command);
        await batchRepository.AddAsync(batch);
        await unitOfWork.CompleteAsync();
        return batch;
    }

    
    //========================== Fermentation ==========================
    public async Task<Batch?> Handle(AddFermentationToBatchCommand command)
    {
        var batch = await batchRepository.FindByIdAsync(command.BatchId);
        if (batch is null) throw new Exception("Batch not found");
        
        batch.AddFermentationToBatch(
            command.BatchId, 
            command.StartDate, 
            command.EndDate, 
            command.AverageTemperature, 
            command.InitialDensity, 
            command.InitialPh, 
            command.FinalDensity, 
            command.FinalPh, 
            command.ResidualSugar);
        
       
        await unitOfWork.CompleteAsync();
        return batch;
    }
    
    //======================== end Fermentation ========================
    
    //========================== Clarification ==========================
    
    public async Task<Batch?> Handle(AddClarificationToBatchCommand command)
    {
        var batch = await batchRepository.FindByIdAsync(command.BatchId);
        if (batch is null) throw new Exception("Batch not found");
        if (batch.Status != CurrentBatchStatus.Fermentation) throw new Exception("The batch must first go through the fermentation stage");
      
        
        Console.WriteLine("batch.Status: " + batch.Status);
        
        batch.AddClarificationToBatch(
            command.BatchId, 
            command.ProductsUsed, 
            command.ClarificationMethod, 
            command.FiltrationDate, 
            command.ClarityLevel, 
            command.StartDate, 
            command.EndDate);
        
        await unitOfWork.CompleteAsync();
        return batch;
    }
    //======================== end Clarification ========================
}