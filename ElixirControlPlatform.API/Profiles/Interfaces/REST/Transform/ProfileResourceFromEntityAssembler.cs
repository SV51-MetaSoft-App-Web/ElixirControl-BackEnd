using ElixirControlPlatform.API.Profiles.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Profiles.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(
            entity.Id,
            entity.FullName,
            entity.EmailAddress,
            entity.CompanyName,
            entity.PhoneNumber,
            entity.RUC,
            entity.StreetAddress
        );
    }

}

