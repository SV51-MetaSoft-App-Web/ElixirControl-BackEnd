namespace ElixirControlPlatform.API.ProductManagement.Domain.Model.Commands;

public record UpdateProductCommand(
    string ProductName,
    string GrapeVariety,
    string WineType,
    string Origin,
    double? AlcoholContent,
    double? Price,
    string FoodPairing,
    int Quantity,
    string ImageUrl
);