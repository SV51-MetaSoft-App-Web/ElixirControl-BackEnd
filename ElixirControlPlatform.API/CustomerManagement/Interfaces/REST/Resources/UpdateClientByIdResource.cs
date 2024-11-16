namespace ElixirControlPlatform.API.CustomerManagement.Interfaces.REST.Resources;

public record UpdateClientByIdResource(
    string PersonName,
    int Dni,
    string Email,
    string BusinessName,
    int Phone,
    string Address,
    string Country,
    string City,
    int Ruc
    );