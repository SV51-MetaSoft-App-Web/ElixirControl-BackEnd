using ElixirControlPlatform.API.ProductManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.ProductManagement.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.ProductManagement.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(
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