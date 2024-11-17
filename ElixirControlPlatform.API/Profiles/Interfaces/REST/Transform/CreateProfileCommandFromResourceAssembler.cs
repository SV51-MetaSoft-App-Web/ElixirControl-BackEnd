using ElixirControlPlatform.API.Profiles.Domain.Model.Commands;
using ElixirControlPlatform.API.Profiles.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(
            resource.FirstName,
            resource.LastName,
            resource.Email,
            resource.CompanyName,
            resource.PhoneNumber,
            resource.RUC,
            resource.Street,
            resource.Number,
            resource.City,
            resource.Country
        );
    }
    
}

