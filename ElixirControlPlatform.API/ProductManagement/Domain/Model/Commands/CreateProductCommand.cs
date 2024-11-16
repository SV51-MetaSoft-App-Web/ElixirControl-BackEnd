namespace ElixirControlPlatform.API.ProductManagement.Domain.Model.Commands;

public record CreateProductCommand(
    string NameProduct,
    string GrapeVariety,
    string WineType,
    string Origin,
    double? AlcoholContent,
    double? Price,
    string FoodPairing,
    int? Quantity,
    string Image
);