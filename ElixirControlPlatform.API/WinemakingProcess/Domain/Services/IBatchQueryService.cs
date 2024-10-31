using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Queries;

namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Services;

public interface IBatchQueryService
{
    Task<IEnumerable<Batch>> Handle(GetAllBatchesQuery query);
    
    Task<Batch?> Handle(GetBatchByIdQuery query);
}