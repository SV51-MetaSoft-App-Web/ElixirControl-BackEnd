using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ElixirControlPlatform.API.OrderManagement.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository(AppDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    
}