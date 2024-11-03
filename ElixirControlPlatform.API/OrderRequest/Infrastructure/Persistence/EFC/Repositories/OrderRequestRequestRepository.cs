using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ElixirControlPlatform.API.OrderRequest.Infrastructure.Persistence.EFC.Repositories;

public class OrderRequestRequestRepository(AppDbContext context): BaseRepository<OrderRequests>(context), IOrderRequestRepository
{
    
}