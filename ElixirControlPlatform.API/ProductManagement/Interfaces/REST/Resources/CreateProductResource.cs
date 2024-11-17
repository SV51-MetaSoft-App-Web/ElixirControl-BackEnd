namespace ElixirControlPlatform.API.ProductManagement.Interfaces.REST.Resources;

public record CreateProductResource(    
    string ProductName,
    string GrapeVariety,
    string WineType,
    string Origin,
    double? AlcoholContent,
    double? Price,
    string FoodPairing,
    int Quantity,
    string ImageUrl);