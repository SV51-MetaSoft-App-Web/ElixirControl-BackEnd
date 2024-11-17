using ElixirControlPlatform.API.ProductManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.ProductManagement.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.ProductManagement.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource  ToResourceFromEntity(Product entity)
    {
        return new ProductResource(
            entity.Id,
            entity.ProductName,
           entity.GrapeVariety,
            entity.WineType,
            entity.Origin,
            entity.AlcoholContent,
            entity.Price,
            entity.FoodPairing,
            entity.Quantity,
            entity.ImageUrl
        );
    }
}