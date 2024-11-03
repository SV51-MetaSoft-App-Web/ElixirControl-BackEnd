using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Domain.Repositories;
using ElixirControlPlatform.API.OrderRequest.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.OrderRequest.Application.Internal.CommandServices;

public class OrderCommandService(IOrderRepository orderRepository, IUnitOfWOrk unitOfWOrk): IOrderCommandService
{
    public async Task<OrderRequests?> Handle(CreateOrderCommand command)
    {
        var order = new OrderRequests(command);
        await orderRepository.AddAsync(order);
        await unitOfWOrk.CompleteAsync();
        return order;

    }
    
}
