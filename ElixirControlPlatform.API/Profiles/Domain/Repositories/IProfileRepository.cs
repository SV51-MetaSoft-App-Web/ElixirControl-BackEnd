using ElixirControlPlatform.API.Profiles.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Profiles.Domain.Model.ValueObjects;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
    
    Task<Profile?> GetProfileByIdAsync(Guid Id);
    
    Task<bool?> existsProfileByEmailAsync(string email);
    
    Task<bool?> ExistsProfileByRUCAsync(string ruc);
    
}