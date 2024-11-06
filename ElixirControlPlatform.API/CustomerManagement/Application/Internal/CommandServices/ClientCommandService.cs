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
    public async Task<Client?> Handle(CreateClientCommand command)
    {
        var client = await clientRepository.FindByDniAsync(command.Dni);
        if (client != null) throw new Exception("Client with DNI already exists");
        client = new Client(command);
        await clientRepository.AddAsync(client);
        await unitOfWork.CompleteAsync();
        return client;
        
        
    }

    public async Task<Client?> Handle(DeleteClientByIdCommand command)
    {
        var client = await clientRepository.FindByIdAsync(command.Id);
        if (client is null) throw new Exception("Client not found");
        clientRepository.Remove(client);
        await unitOfWork.CompleteAsync();
        return client;
    }
    
    public async Task<Client?> Handle(UpdateClientByIdCommand command)
    {
        var client = await clientRepository.FindByIdAsync(command.Id);
        if (client is null) throw new Exception("Client not found");
        var client2 = await clientRepository.FindByDniAsync(command.Dni);
        if (client2 != null && client2.Id != command.Id) throw new Exception("Client with DNI already exists");
        client.UpdateClientById(command);
        clientRepository.Update(client);
        await unitOfWork.CompleteAsync();
        return client;
    }
}