using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.InventoryManagement.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;


namespace ElixirControlPlatform.API.InventoryManagement.Application.Internal.CommandServices;

public class InventoryCommandService : IInventoryCommandService
{
    private readonly IUnitOfWOrk unitOfWork;

    public InventoryCommandService(IUnitOfWOrk unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Inventory?> Handle(CreateInventoryCommand command)
    {
        var inventory = new Inventory(command);
        await unitOfWork.CompleteAsync();
        return inventory;
    }
}