using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Queries;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Services;

namespace ElixirControlPlatform.API.WinemakingProcess.Application.Internal.QueryServices;

public class BatchQueryService(IBatchRepository batchRepository) : IBatchQueryService
{
    
    public async Task<Batch?> Handle(GetBatchByIdQuery query)
    {
        return await batchRepository.FindByIdAsync(query.Id);
    }
    
    
    public async Task<IEnumerable<Batch>> Handle(GetAllBatchesQuery query)
    {
        return await batchRepository.ListAsync();
    }
    
}