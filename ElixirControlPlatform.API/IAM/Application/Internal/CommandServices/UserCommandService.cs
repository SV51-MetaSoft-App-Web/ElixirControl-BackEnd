using ElixirControlPlatform.API.IAM.Application.Internal.OutboundServices;
using ElixirControlPlatform.API.IAM.Domain.Model.Aggregates;
using ElixirControlPlatform.API.IAM.Domain.Model.Commands;
using ElixirControlPlatform.API.IAM.Domain.Repositories;
using ElixirControlPlatform.API.IAM.Domain.Services;
using ElixirControlPlatform.API.Profiles.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Profiles.Domain.Model.Commands;
using ElixirControlPlatform.API.Profiles.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.IAM.Application.Internal.CommandServices;

/// <summary>
/// User command service 
/// </summary>
/// <param name="userRepository">
/// The <see cref="IUserRepository"/> instance
/// </param>
/// <param name="tokenService">
/// The <see cref="ITokenService"/> instance
/// </param>
/// <param name="hashingService">
/// The <see cref="IHashingService"/> instance
/// </param>
/// <param name="unitOfWork">
/// The <see cref="IUnitOfWOrk"/> instance
/// </param>
public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService, IProfileRepository profileRepository,
    IUnitOfWOrk unitOfWork
    ) : IUserCommandService
{
    // <inheritdoc/>
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} already exists");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the user: {e.Message}");
        }
        //string firstName, string lastName, string email, string companyName, string phoneNumber, string ruc, string street, string number, string city, string country
        
        //combinar user name con @gmail.com
        var profile = new Profile( new CreateProfileCommand( 
            user.Username, 
            user.Username, 
            user.Username + "@gmail.com", 
            "MetaSoft", 
            "0987654321", 
            "123456789",
            "Calle 1",
            "123",
            "Cuenca",
            "Ecuador"
            ), user.Id);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the profile: {e.Message}");
        }
    }

    // <inheritdoc/>
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        if (user is null) throw new Exception($"User {command.Username} not found");
        if (!hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid password");
        var token = tokenService.GenerateToken(user);
        return (user, token);
    }
}