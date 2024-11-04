using ElixirControlPlatform.API.Shared.Domain.Repositories;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.ValueObjects;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Services;

namespace ElixirControlPlatform.API.WinemakingProcess.Application.Internal.CommandServices;

public class BatchCommandService(IBatchRepository batchRepository, IUnitOfWOrk unitOfWork) : IBatchCommandService
{

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
        
        batch.AddFermentationByBatch(
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
    
    public async Task<Batch?> Handle(DeleteFermentationByBatchCommand command)
    {
        var batch = await batchRepository.FindByIdAsync(command.BatchId);
        var fermentation = await batchRepository.GetFermentationByBatchAsync(command.BatchId);
        
        if (batch is null) throw new Exception("Batch not found");
        if (fermentation is null) throw new Exception("The batch has no registered fermentation");
 
        batch.DeleteFermentationByBatch();
        
        batchRepository.Update(batch);
        
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
        
        batch.AddClarificationByBatch(
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
    
    public async Task<Batch?> Handle(DeleteClarificationByBatchCommand command)
    {
        var batch = await batchRepository.FindByIdAsync(command.BatchId);
        var clarification = await batchRepository.GetClarificationByBatchAsync(command.BatchId);
        
        if (batch is null) throw new Exception("Batch not found");
        if (clarification is null) throw new Exception("The batch has no registered clarification");
        
        batch.DeleteClarificationByBatch();
        
        batchRepository.Update(batch);
        
        await unitOfWork.CompleteAsync();
        return batch;
    }
 
    
    //======================== end Clarification ========================
    
    
    //========================== Pressing ==========================
    
    public async Task<Batch?> Handle(AddPressingToBatchCommand command)
    {
        var batch = await batchRepository.FindByIdAsync(command.BatchId);
        if (batch is null) throw new Exception("Batch not found");
        if (batch.Status != CurrentBatchStatus.Clarification) throw new Exception("The batch must first go through the clarification stage");
        
        batch.AddPressingByBatch(
            command.BatchId, 
            command.PressingDate, 
            command.MustVolume, 
            command.PressType, 
            command.AppliedPressure);
        
        await unitOfWork.CompleteAsync();
        return batch;
    }
    
    public async Task<Batch?> Handle(DeletePressingByBatchCommand command)
    {
        var batch = await batchRepository.FindByIdAsync(command.BatchId);
        var pressing = await batchRepository.GetPressingByBatchAsync(command.BatchId);
        
        if (batch is null) throw new Exception("Batch not found");
        if (pressing is null) throw new Exception("The batch has no registered pressing");
        
        batch.DeletePressingByBatch();
        
        batchRepository.Update(batch);
        
        await unitOfWork.CompleteAsync();
        return batch;
    }
    
    //======================== end Pressing ========================
    
    //========================== Aging ==========================
    
    public async Task<Batch?> Handle(AddAgingToBatchCommand command)
    {
        var batch = await batchRepository.FindByIdAsync(command.BatchId);
        if (batch is null) throw new Exception("Batch not found");
        if (batch.Status != CurrentBatchStatus.Pressing) throw new Exception("The batch must first go through the pressing stage");
        
        batch.AddAgingByBatch(
            command.BatchId, 
            command.BarrelType, 
            command.StartDate, 
            command.EndDate, 
            command.AgingDurationMonths, 
            command.InspectionsPerformed, 
            command.InspectionResult);
        
        await unitOfWork.CompleteAsync();
        return batch;
    }

    public async Task<Batch?> Handle(DeleteAgingByBatchCommand command)
    {
        var batch = await batchRepository.FindByIdAsync(command.BatchId);
        var aging = await batchRepository.GetAgingByBatchAsync(command.BatchId);
        
        if (batch is null) throw new Exception("Batch not found");
        if (aging is null) throw new Exception("The batch has no registered aging");
        
        batch.DeleteAgingByBatch();
        
        batchRepository.Update(batch);
        
        await unitOfWork.CompleteAsync();
        return batch;
    }
    //======================== end Aging ========================
}