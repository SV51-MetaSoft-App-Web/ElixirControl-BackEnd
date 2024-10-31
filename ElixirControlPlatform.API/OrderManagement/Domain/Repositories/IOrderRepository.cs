using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.APII.Shared.Domain.Repositories;

//namespace ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
namespace ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
public interface IOrderRepository : IBaseRepository<Order>
{
    
}