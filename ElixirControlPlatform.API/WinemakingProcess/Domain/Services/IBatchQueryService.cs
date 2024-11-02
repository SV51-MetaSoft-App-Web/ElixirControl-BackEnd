using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Queries;

namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Services;

public interface IBatchQueryService
{
    
    Task<Batch?> Handle(GetBatchByIdQuery query);
    
    Task<IEnumerable<Batch>> Handle(GetAllBatchesQuery query);
}