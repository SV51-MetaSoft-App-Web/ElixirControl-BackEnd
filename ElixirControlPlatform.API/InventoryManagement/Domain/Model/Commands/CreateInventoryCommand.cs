namespace ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;

public record CreateInventoryCommand(
    string Name,
    string Type,
    string Unit,
    DateTime Expiration,
    string Supplier,
    decimal CostPerUnit,
    int Quantity);