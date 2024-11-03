using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class InventoryResourceFromEntityAssembler
{
    public static InventoryResource ToResourceFromEntity(Inventory entity)
    {
        return new InventoryResource(
            entity.Id,
            entity.Name,
            entity.Type, 
            entity.Unit,   
            entity.Expiration,     
            entity.Supplier,
            entity.CostPerUnit,
            entity.LastUpdated,   
            entity.Quantity
        );
    }
}