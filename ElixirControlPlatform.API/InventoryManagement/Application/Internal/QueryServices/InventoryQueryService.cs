using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.InventoryManagement.Domain.Repositories;
using ElixirControlPlatform.API.InventoryManagement.Domain.Services;

namespace ElixirControlPlatform.API.InventoryManagement.Application.Internal.QueryServices;

public class InventoryQueryService : IInventoryQueryService
{
    private readonly IInventoryRepository inventoryRepository;

    public InventoryQueryService(IInventoryRepository inventoryRepository)
    {
        this.inventoryRepository = inventoryRepository;
    }

    public async Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query)
    {
        // Lógica para obtener todos los inventarios
        return await Task.FromResult<IEnumerable<Inventory>>(new List<Inventory>());
    }

    public async Task<Inventory?> Handle(GetInventoryByIdQuery query)
    {
        // Lógica para obtener un inventario por ID
        return await Task.FromResult<Inventory?>(null);
    }
}