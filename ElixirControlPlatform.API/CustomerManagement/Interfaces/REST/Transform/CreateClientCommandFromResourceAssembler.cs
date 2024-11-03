using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.CustomerManagement.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.CustomerManagement.Interfaces.REST.Transform;

/// <summary>
/// Assembler to create a client command from a resource
/// </summary>
public static class CreateClientCommandFromResourceAssembler
{
    /// <summary>
    /// Converts a <see cref="CreateClientResource"/> to a <see cref="CreateClientsSourceCommand"/>
    /// </summary>
    /// <param name="resource">The <see cref="CreateClientResource"/> resource</param>
    /// <returns>
    /// A <see cref="CreateClientsSourceCommand"/> command
    /// </returns>
    public static CreateClientsSourceCommand ToCommandFromResource(CreateClientResource resource)
    {
        return new CreateClientsSourceCommand(resource.PersonName, resource.Dni, resource.Email, resource.BusinessName, resource.Phone, resource.Address, resource.Country, resource.City, resource.Ruc);
    }
}