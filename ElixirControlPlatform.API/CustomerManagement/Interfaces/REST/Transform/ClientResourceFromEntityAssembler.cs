using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
using ElixirControlPlatform.API.CustomerManagement.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.CustomerManagement.Interfaces.REST.Transform;

/// <summary>
/// Assembler to create a client resource from an entity
/// </summary>
public static class ClientResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a <see cref="Client"/> entity to a <see cref="ClientResource"/>
    /// </summary>
    /// <param name="entity">The <see cref="Client"/> entity</param>
    /// <returns>
    /// A <see cref="ClientResource"/> resource
    /// </returns>
    public static ClientResource ToResourceFromEntity(Client entity)
    {
        return new ClientResource(entity.Id,entity.PersonName, entity.Dni, entity.Email, entity.BusinessName, entity.Phone, entity.Address, entity.Country, entity.City, entity.Ruc);
    }
}       