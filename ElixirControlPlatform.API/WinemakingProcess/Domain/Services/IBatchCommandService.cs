using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Services;

public interface IBatchCommandService
{
    public Task<Batch?> Handle(CreateBatchCommand command, Guid profileId);
    
    //=========== Fermentation
    public Task<Batch?> Handle(AddFermentationToBatchCommand command);
    public Task<Batch?> Handle(DeleteFermentationByBatchCommand command);
    public Task<Batch?> Handle(UpdateFermentationByBatchCommand command, int batch);   
    
    // =========== end Fermentation
    
    //=========== Clarification
    public Task<Batch?> Handle(AddClarificationToBatchCommand command);
    public Task<Batch?> Handle(DeleteClarificationByBatchCommand command);
    public Task<Batch?> Handle(UpdateClarificationByBatchCommand command, int batch);
    
    // =========== end Clarification
    
    //=========== Pressing
    public Task<Batch?> Handle(AddPressingToBatchCommand command);
    public Task<Batch?> Handle(DeletePressingByBatchCommand command);
    public Task<Batch?> Handle(UpdatePressingByBatchCommand command, int batch);
    // =========== end Pressing
    
    
    //=========== Aging
    public Task<Batch?> Handle(AddAgingToBatchCommand command);
    public Task<Batch?> Handle(DeleteAgingByBatchCommand command);
    public Task<Batch?> Handle(UpdateAgingByBatchCommand command, int batch);
    // =========== end Aging
    
    
}