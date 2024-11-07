using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Queries;

namespace ElixirControlPlatform.API.InventoryManagement.Domain.Services;

public interface IInventoryQueryService
{
    Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query);
        
    Task<Inventory?> Handle(GetInventoryByIdQuery query);
    
    Task<IEnumerable<Inventory>> Handle(GetInventoriesByFilterQuery query);
}