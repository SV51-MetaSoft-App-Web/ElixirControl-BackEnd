namespace ElixirControlPlatform.API.InventoryManagement.Domain.Model.Queries;

public record GetInventoriesByFilterQuery(string? Name, string? Unit, string? Type);