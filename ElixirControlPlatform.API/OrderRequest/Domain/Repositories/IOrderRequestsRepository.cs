using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Repositories;

public interface IOrderRequestsRepository : IBaseRepository<OrderRequests>
{
    
}
