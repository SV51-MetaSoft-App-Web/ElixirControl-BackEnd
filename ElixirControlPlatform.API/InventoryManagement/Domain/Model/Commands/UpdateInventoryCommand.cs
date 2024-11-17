namespace ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;

public record UpdateInventoryCommand(
int Id,
string Name,
string Type,
string Unit,
DateTime Expiration,
string Supplier,
decimal CostPerUnit,
int Quantity);