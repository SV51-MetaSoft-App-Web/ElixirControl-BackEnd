using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
using ElixirControlPlatform.API.OrderManagement.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;
using System.Threading.Tasks;

namespace ElixirControlPlatform.API.OrderManagement.Application.Internal.CommandServices;

/// <summary>
/// Order command service
/// </summary>
public class OrderCommandService(IOrderRepository orderRepository, IUnitOfWOrk unitOfWork) : IOrderCommandService
{

    
    public async Task<Order?> Handle(CreateOrderSourceCommand command)
    {
        var order = new Order(command);
        
            await orderRepository.AddAsync(order);
            await unitOfWork.CompleteAsync();

        return order;
    }
}