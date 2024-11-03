using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

//namespace ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
namespace ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
public interface IOrderRepository : IBaseRepository<Order>
{
    
}