using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirControlPlatform.API.WinemakingProcess.Infrastructure.Persistence.EFC.Repositories;

public class BatchRepository(AppDbContext context) : BaseRepository<Batch>(context), IBatchRepository
{

    public async Task<Fermentation?> GetFermentationByBatchAsync(int batchId)
    {
        return await Context.Set<Fermentation>()
            .FirstOrDefaultAsync(fermentation => fermentation.BatchId == batchId);
    }
    
    public async Task<Clarification?> GetClarificationByBatchAsync(int batchId)
    {
        return await Context.Set<Clarification>()
            .FirstOrDefaultAsync(clarification => clarification.BatchId == batchId);
    }
    
    public async Task<Pressing?> GetPressingByBatchAsync(int batchId)
    {
        return await Context.Set<Pressing>()
            .FirstOrDefaultAsync(pressing => pressing.BatchId == batchId);
    }
    
}