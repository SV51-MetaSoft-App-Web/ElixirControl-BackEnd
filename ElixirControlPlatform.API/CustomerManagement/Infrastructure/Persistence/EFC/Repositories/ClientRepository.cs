
using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.CustomerManagement.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirControlPlatform.API.CustomerManagement.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Client repository
/// </summary>
/// <param name="context">The <see cref="AppDbContext"/> Database Context</param>
public class ClientRepository(AppDbContext context)
: BaseRepository<Client>(context), IClientRepository
{
    
    /// <inheritdoc cref="IClientRepository.FindByDniAsync"/>
    public async Task<Client?> FindByDniAsync(int dni)
    {
        return await Context.Set<Client>().FirstOrDefaultAsync(client => client.Dni == dni);
    }

    public async Task<IEnumerable<Client>> GetAllClientsByProfileId(GetAllClientsByProfileId query)
    {
        return await Context.Set<Client>().Where(client => client.ProfileId == query.ProfileId).ToListAsync();
    }
}