namespace ElixirControlPlatform.API.CustomerManagement.Interfaces.REST.Resources;

public record UpdateClientByIdResource(
    string PersonName,
    string Dni,
    string Email,
    string BusinessName,
    string Phone,
    string Address,
    string Country,
    string City,
    string Ruc
    );