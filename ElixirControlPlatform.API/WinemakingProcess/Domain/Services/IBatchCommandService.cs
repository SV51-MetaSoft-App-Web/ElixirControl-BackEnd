using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Services;

public interface IBatchCommandService
{
    
    public Task<Batch?> Handle(AddFermentationToBatchCommand command);
    
    public Task<Batch?> Handle(CreateBatchCommand command);
    
}