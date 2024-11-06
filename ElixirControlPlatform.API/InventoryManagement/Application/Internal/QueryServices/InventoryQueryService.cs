using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.InventoryManagement.Domain.Repositories;
using ElixirControlPlatform.API.InventoryManagement.Domain.Services;

namespace ElixirControlPlatform.API.InventoryManagement.Application.Internal.QueryServices;

public class InventoryQueryService(IInventoryRepository inventoryRepository) : IInventoryQueryService
{
    public async Task<Inventory?> Handle(GetInventoryByIdQuery query)
    {
        return await inventoryRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query)
    {
        return await inventoryRepository.ListAsync();
    }
    public async Task<IEnumerable<Inventory>> Handle(GetInventoriesByFilterQuery query)
    {
        return await inventoryRepository.SearchAsync(query.Name, query.Unit, query.Type);
    }
}