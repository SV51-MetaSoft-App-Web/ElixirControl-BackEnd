using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.CustomerManagement.Domain.Repositories;
using ElixirControlPlatform.API.CustomerManagement.Domain.Services;
namespace ElixirControlPlatform.API.CustomerManagement.Application.Internal.QueryServices;

/// <summary>
/// Query service for clients
/// </summary>
/// <param name="clientRepository">ClientRepository instance</param>
public class ClientQueryService(IClientRepository clientRepository) : IClientQueryService
{
    /// <inheritdoc cref="IClientQueryService.Handle(GetClientByIdQuery)"/>
    public async Task<Client?> Handle(GetClientByIdQuery query)
    {
        return await clientRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<Client?> Handle(GetAllClientsByDniQuery query)
    {
        return await clientRepository.FindByDniAsync(query.Dni);
    }
    
    public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery query)
    {
        return await clientRepository.ListAsync();
    }
}