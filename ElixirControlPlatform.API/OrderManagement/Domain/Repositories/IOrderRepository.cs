using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Shared.Domain.Repositories;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Queries;   

//namespace ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
namespace ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
public interface IOrderRepository : IBaseRepository<Order>
{

    Task<IEnumerable<Order>> GetAllOrdersByProfileId(GetAllOrdersByProfileId query);
    //Task<Order> GetOrderById(Guid orderId);
}