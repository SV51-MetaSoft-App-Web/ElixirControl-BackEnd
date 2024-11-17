namespace ElixirControlPlatform.API.ProductManagement.Domain.Model.Queries;

public record GetAllProductsByProfileIdAndProductName(Guid ProfileId ,string ProductName);