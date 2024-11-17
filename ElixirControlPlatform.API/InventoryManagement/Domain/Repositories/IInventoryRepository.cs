using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.InventoryManagement.Domain.Repositories;

public interface IInventoryRepository : IBaseRepository<Inventory>
{
    Task<Inventory?> GetByIdAsync(int id); 
    Task<IEnumerable<Inventory>> GetAllAsync();
    
    
    Task<IEnumerable<Inventory>> SearchAsync(string? name, string? unit, string? type);
    Task UpdateAsync(Inventory inventory);
    
    Task DeleteAsync(Inventory inventory);
}