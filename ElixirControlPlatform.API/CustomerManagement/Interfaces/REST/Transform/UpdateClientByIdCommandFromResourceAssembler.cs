using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.CustomerManagement.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.CustomerManagement.Interfaces.REST.Transform;

public static class UpdateClientByIdCommandFromResourceAssembler
{
    
    public static UpdateClientByIdCommand ToCommandFromResource(int id,UpdateClientByIdResource resource)
    {
        return new UpdateClientByIdCommand(
            Id: id,
            PersonName: resource.PersonName,
            Dni: resource.Dni,
            Email: resource.Email,
            BusinessName: resource.BusinessName,
            Phone: resource.Phone,
            Address: resource.Address,
            Country: resource.Country,
            City: resource.City,
            Ruc: resource.Ruc
        );
    }
    
}