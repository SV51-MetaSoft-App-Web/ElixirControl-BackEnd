using ElixirControlPlatform.API.Profiles.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Profiles.Domain.Model.ValueObjects;
using ElixirControlPlatform.API.Profiles.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirControlPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    
    /// <inheritdoc />
    public async Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().FirstOrDefault(p => p.Email == email);
    }
    
    public async Task<Profile?> GetProfileByProfileIdAsync(string profileId)
    {
        return await Context.Set<Profile>().FirstOrDefaultAsync(p => p.ProfileId.ToString() == profileId);
    }

    public async Task<bool?> existsProfileByEmailAsync(string email)
    {
        return await Context.Set<Profile>().AnyAsync(p => p.EmailAddress == email);
    }

    public async  Task<bool?> existsProfileByProfileIdAsync(string profileId)
    {
        return await Context.Set<Profile>().AnyAsync(p => p.GetProfileId() == profileId);
    }

    public async  Task<bool?> ExistsProfileByRUCAsync(string ruc)
    {
        return await Context.Set<Profile>().AnyAsync(p => p.RUC == ruc);
    }
}