namespace ElixirControlPlatform.API.Profiles.Interfaces.REST.Resources;

public record ProfileResource(
    int Id, 
    Guid ProfileId,
    string FullName, 
    string Email, 
    string CompanyName,
    string PhoneNumber,
    string RUC,
    string StreetAddress);