namespace ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;

public record CreateInventoryCommand(
    int Id,
    string Name,
    string Type,
    string Unit,
    DateTime Expiration,
    string Supplier,
    decimal CostPerUnit,
    DateTime LastUpdated,
    int Quantity);