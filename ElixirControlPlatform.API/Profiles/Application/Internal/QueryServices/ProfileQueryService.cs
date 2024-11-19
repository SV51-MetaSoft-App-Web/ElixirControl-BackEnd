using ElixirControlPlatform.API.Profiles.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Profiles.Domain.Model.Queries;
using ElixirControlPlatform.API.Profiles.Domain.Repositories;
using ElixirControlPlatform.API.Profiles.Domain.Services;
using ElixirControlPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

namespace ElixirControlPlatform.API.Profiles.Application.Internal.QueryServices;


/// <summary>
/// Profile query service 
/// </summary>
/// <param name="profileRepository">
/// Profile repository
/// </param>
public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    /// <inheritdoc />
    public async  Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }
    
    /// <inheritdoc />
    public async Task<Profile?> Handle(GetProfileByEmailQuery query)
    {
        return await profileRepository.FindProfileByEmailAsync(query.Email);
    }
    
    /// <inheritdoc />
    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.GetProfileByIdAsync(query.Id);
    }
    
    public async Task<Profile?> Handle(GetProfileByUserIdQuery query)
    {
        return await profileRepository.GetProfileByUserIdAsync(query.UserId);
    }

}