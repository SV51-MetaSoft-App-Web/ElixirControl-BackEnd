using ElixirControlPlatform.API.ProductManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.ProductManagement.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.ProductManagement.Interfaces.REST.Transform;

public static class UpdateProductCommandFromResourceAssembler
{
    public static UpdateProductCommand ToCommandFromResource(UpdateProductResource resource)
    {
        return new UpdateProductCommand(
            resource.ProductName,
            resource.GrapeVariety,
            resource.WineType,
            resource.Origin,
            resource.AlcoholContent,
            resource.Price,
            resource.FoodPairing,
            resource.Quantity,
            resource.ImageUrl
        );
    }
    
}