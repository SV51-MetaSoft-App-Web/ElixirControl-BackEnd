using ElixirControlPlatform.API.IAM.Domain.Model.Commands;
using ElixirControlPlatform.API.IAM.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.IAM.Interfaces.REST.Transform;

/// <summary>
/// Represents the assembler for the sign-in command from resource. 
/// </summary>
public static class SignInCommandFromResourceAssembler
{
    /// <summary>
    /// Converts the sign-in resource to the sign-in command. 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="SignInResource"/> resource.
    /// </param>
    /// <returns>
    /// The <see cref="SignInCommand"/> command.
    /// </returns>
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}