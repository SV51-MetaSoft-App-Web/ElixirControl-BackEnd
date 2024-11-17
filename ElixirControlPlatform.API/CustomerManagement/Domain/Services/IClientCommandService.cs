using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Commands;

namespace ElixirControlPlatform.API.CustomerManagement.Domain.Services;

/// <summary>
/// Client command service interface
/// </summary>
public interface IClientCommandService
{
    /// <summary>
    /// Handle create client command
    /// </summary>
    /// <param name="command">The CreateClientsSourceCommand</param>
    /// <returns>
    /// The created client if successful otherwise null
    /// </returns>
    /// <see cref="CreateClientCommand"/>
    Task<Client?> Handle(CreateClientCommand command);
    
    Task<Client?> Handle(DeleteClientByIdCommand command);
    
    Task<Client?> Handle(UpdateClientByIdCommand command);
}   