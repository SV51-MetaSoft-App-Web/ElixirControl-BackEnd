using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Services;

public interface IBatchCommandService
{
    public Task<Batch?> Handle(CreateBatchCommand command);
    
    //=========== Fermentation
    public Task<Batch?> Handle(AddFermentationToBatchCommand command);
    public Task<Batch?> Handle(DeleteFermentationByBatchCommand command);
    
    // =========== end Fermentation
    
    //=========== Clarification
    public Task<Batch?> Handle(AddClarificationToBatchCommand command);
    public Task<Batch?> Handle(DeleteClarificationByBatchCommand command);
    
    // =========== end Clarification
    
    //=========== Pressing
    public Task<Batch?> Handle(AddPressingToBatchCommand command);
    public Task<Batch?> Handle(DeletePressingByBatchCommand command);
    
    // =========== end Pressing
    
    
    //=========== Aging
    public Task<Batch?> Handle(AddAgingToBatchCommand command);
    public Task<Batch?> Handle(DeleteAgingByBatchCommand command);
    
    // =========== end Aging
    
    
}