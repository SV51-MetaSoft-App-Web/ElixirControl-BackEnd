using System.Reflection.Metadata;
using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.CustomerManagement.Domain.Repositories;
using ElixirControlPlatform.API.CustomerManagement.Domain.Services;
using ElixirControlPlatform.API.Profiles.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.CustomerManagement.Application.Internal.CommandServices;

/// <summary>
/// Client command service
/// </summary>
/// <param name="clientRepository">ClientRepository instance</param>
/// <param name="unitOfWork">Unit of Work instance</param>
/// 
public class ClientCommandService(IClientRepository clientRepository, IProfileRepository profileRepository, IUnitOfWOrk unitOfWork) : IClientCommandService
{
    /// <inheritdoc cref="System.Reflection.Metadata.Handle"/>
    public async Task<Client?> Handle(CreateClientCommand command, Guid profileId)
    {
        var client = await clientRepository.FindByDniAsync(command.Dni);
        if (client != null) throw new Exception("Client with DNI already exists");
        var profile =  await profileRepository.GetProfileByIdAsync(profileId);
        if (profile is null) throw new Exception("Profile not found");
        if (command.Dni.ToString().Length != 7) throw new Exception("DNI must have 7 digits");
        if (command.Phone.ToString().Length != 9) throw new Exception("Phone must have 9 digits");
        client = new Client(command, profileId);
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
        if (command.Dni.ToString().Length != 7) throw new Exception("DNI must have 7 digits");
        if (command.Phone.ToString().Length != 9) throw new Exception("Phone must have 9 digits");
        client.UpdateClientById(command);
        clientRepository.Update(client);
        await unitOfWork.CompleteAsync();
        return client;
    }
   
    
}