using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ElixirControlPlatform.API.OrderManagement.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository(AppDbContext context) : BaseRepository<Orders>(context), IOrderRepository
{
    
}