using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.InventoryManagement.Domain.Repositories;
using ElixirControlPlatform.API.InventoryManagement.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;


namespace ElixirControlPlatform.API.InventoryManagement.Application.Internal.CommandServices;

public class InventoryCommandService(IInventoryRepository inventoryRepository, IUnitOfWOrk unitOfWork) : IInventoryCommandService
{
    public async Task<Inventory?> Handle(CreateInventoryCommand command)
    {
        var inventory = new Inventory(command); 
        await inventoryRepository.AddAsync(inventory); 
        await unitOfWork.CompleteAsync();
        return inventory;
    }
}