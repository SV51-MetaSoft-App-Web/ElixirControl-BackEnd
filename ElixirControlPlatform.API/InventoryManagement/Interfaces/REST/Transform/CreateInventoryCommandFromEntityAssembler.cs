using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class CreateInventoryCommandFromResourceAssembler
{
    public static CreateInventoryCommand ToCommandFromResource(CreateInventoryResource resource)
    {
        return new CreateInventoryCommand(
            resource.Id,
            resource.Name,
            resource.Type,
            resource.Unit,
            resource.Expiration,
            resource.Supplier,
            resource.CostPerUnit,
            resource.LastUpdated,
            resource.Quantity
        );
    }
}