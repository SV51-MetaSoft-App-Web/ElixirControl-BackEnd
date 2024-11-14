using ElixirControlPlatform.API.Profiles.Domain.Model.ValueObjects;

namespace ElixirControlPlatform.API.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);