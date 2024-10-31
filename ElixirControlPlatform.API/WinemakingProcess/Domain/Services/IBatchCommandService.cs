using ElixirControlPlatform.API.Shared.Domain.Repositories;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Services;

public interface IBatchCommandService
{
    public Task<Batch?> Handle(CreateBatchCommand command);
}