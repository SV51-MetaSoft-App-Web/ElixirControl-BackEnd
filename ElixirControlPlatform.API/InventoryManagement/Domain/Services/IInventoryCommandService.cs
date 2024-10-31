using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;

namespace ElixirControlPlatform.API.InventoryManagement.Domain.Services;

public interface IInventoryCommandService
{
    Task<Inventory?> Handle(CreateInventoryCommand command);
}