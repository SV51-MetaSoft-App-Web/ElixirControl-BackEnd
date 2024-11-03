
using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
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
    public async Task<Client?> FindByDniAsync(string dni)
    {
        return await Context.Set<Client>().FirstOrDefaultAsync(client => client.Dni == dni);
    }
}