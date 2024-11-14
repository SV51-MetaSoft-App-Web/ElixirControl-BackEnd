using ElixirControlPlatform.API.Profiles.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Profiles.Domain.Model.Commands;
using ElixirControlPlatform.API.Profiles.Domain.Repositories;
using ElixirControlPlatform.API.Profiles.Domain.Services;
using ElixirControlPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.Profiles.Application.Internal.CommandServices;


/// <summary>
/// Profile command service 
/// </summary>
/// <param name="profileRepository">
/// Profile repository
/// </param>
/// <param name="unitOfWork">
/// Unit of work
/// </param>
public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWOrk unitOfWork) : IProfileCommandService
{
    
    /// <inheritdoc />
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);

        //if ((bool)await profileRepository.existsProfileByEmailAsync(command.Email)) throw new Exception("Email already exists");
        
        if ((bool)await profileRepository.ExistsProfileByRUCAsync(command.RUC)) throw new Exception("RUC already exists");
        
        await profileRepository.AddAsync(profile);
        await unitOfWork.CompleteAsync();
        
        return profile;
    }
 
}