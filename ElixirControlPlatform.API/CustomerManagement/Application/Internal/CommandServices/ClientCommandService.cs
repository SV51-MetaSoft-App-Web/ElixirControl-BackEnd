using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.CustomerManagement.Domain.Repositories;
using ElixirControlPlatform.API.CustomerManagement.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.CustomerManagement.Application.Internal.CommandServices;

/// <summary>
/// Client command service
/// </summary>
/// <param name="clientRepository">ClientRepository instance</param>
/// <param name="unitOfWork">Unit of Work instance</param>
/// 
public class ClientCommandService(IClientRepository clientRepository, IUnitOfWOrk unitOfWork) : IClientCommandService
{
    /// <inheritdoc cref="IClientCommandService.Handle"/>
    public async Task<Client?> Handle(CreateClientsSourceCommand command)
    {
        var client =
            await clientRepository.FindByDniAsync(command.Dni);
        if (client != null)
            throw new Exception("Client with DNI already exists");
        client = new Client(command);
        await clientRepository.AddAsync(client);
        await unitOfWork.CompleteAsync();
        return client;
    }
    
    
    
}