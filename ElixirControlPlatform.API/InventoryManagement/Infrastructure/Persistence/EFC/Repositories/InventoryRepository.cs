using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.InventoryManagement.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirControlPlatform.API.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository(AppDbContext context) : BaseRepository<Inventory>(context), IInventoryRepository
{
    public async Task<Inventory> AddAsync(Inventory inventory)
    {
        await Context.Set<Inventory>().AddAsync(inventory); 
        await Context.SaveChangesAsync();
        return inventory;
    }

    public async Task<Inventory?> GetByIdAsync(int id)
    {
        return await Context.Set<Inventory>().FindAsync(id); 
    }

    public async Task<IEnumerable<Inventory>> GetAllAsync()
    {
        return await Context.Set<Inventory>().ToListAsync(); 
    }
    public async Task<IEnumerable<Inventory>> SearchAsync(string? name, string? unit, string? type)
    {
        var query = Context.Set<Inventory>().AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(i => i.Name.Contains(name));
        }

        if (!string.IsNullOrEmpty(unit))
        {
            query = query.Where(i => i.Unit == unit);
        }

        if (!string.IsNullOrEmpty(type))
        {
            query = query.Where(i => i.Type == type);
        }

        return await query.ToListAsync();
    }
    public async Task UpdateAsync(Inventory inventory)
    {
        Context.Set<Inventory>().Update(inventory); 
        await Context.SaveChangesAsync(); 
    }
    
    public async Task DeleteAsync(Inventory inventory)
    {
        Context.Set<Inventory>().Remove(inventory);
        await Context.SaveChangesAsync();
    }
}