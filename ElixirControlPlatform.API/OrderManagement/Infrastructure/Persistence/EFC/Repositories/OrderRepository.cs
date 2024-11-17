using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
namespace ElixirControlPlatform.API.OrderManagement.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository(AppDbContext context) : BaseRepository<Order>(context), IOrderRepository
{

    public async Task<IEnumerable<Order>> GetAllOrdersByProfileId(GetAllOrdersByProfileId query)
    {
        return await Context.Set<Order>().Where(order => order.ProfileId == query.ProfileId).ToListAsync();
    }
    
}