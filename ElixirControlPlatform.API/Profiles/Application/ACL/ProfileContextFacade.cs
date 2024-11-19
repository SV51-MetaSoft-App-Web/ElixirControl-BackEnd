using ElixirControlPlatform.API.Profiles.Domain.Model.Commands;
using ElixirControlPlatform.API.Profiles.Domain.Model.Queries;
using ElixirControlPlatform.API.Profiles.Domain.Model.ValueObjects;
using ElixirControlPlatform.API.Profiles.Domain.Services;
using ElixirControlPlatform.API.Profiles.Interfaces.ACL;

namespace ElixirControlPlatform.API.Profiles.Application.ACL;

public class ProfileContextFacade( IProfileCommandService profileCommandService, IProfileQueryService profileQueryService) : IProfilesContextFacade
{
    public async Task<Guid> CreateProfile(
        int userId,
        string firstName, 
        string lastName, 
        string email, 
        string companyName, 
        string phoneNumber, 
        string ruc,
        string street, 
        string number, 
        string city, 
        string country)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, companyName, phoneNumber, ruc, street, number, city, country);
        
        var profile = await profileCommandService.Handle(createProfileCommand, userId);
        
        return profile?.Id ?? Guid.Empty;
    }

    public async Task<Guid> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));

        var profile = await profileQueryService.Handle(getProfileByEmailQuery);

        return profile?.Id ?? Guid.Empty;
    }
}