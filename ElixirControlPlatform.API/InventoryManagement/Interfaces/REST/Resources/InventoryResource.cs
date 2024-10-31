namespace ElixirControlPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record InventoryResource(
    int Id,
    string Name,
    string Type,
    string Unit,
    DateTime Expiration,
    string Supplier,
    decimal CostPerUnit,
    DateTime LastUpdated,
    int Quantity);