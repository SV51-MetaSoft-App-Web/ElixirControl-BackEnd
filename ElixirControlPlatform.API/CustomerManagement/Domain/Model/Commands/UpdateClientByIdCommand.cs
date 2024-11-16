namespace ElixirControlPlatform.API.CustomerManagement.Domain.Model.Commands;

public record UpdateClientByIdCommand(int Id,string PersonName, int Dni, string Email, string BusinessName, int Phone, string Address, string Country, string City, int Ruc);
