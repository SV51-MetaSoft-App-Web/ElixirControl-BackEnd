using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Domain.Repositories;
using ElixirControlPlatform.API.OrderRequest.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.OrderRequest.Application.Internal.CommandServices;

public class OrderRequestRequestCommandService(IOrderRequestRepository orderRequestRepository, IUnitOfWOrk unitOfWOrk): IOrderRequestCommandService
{
    public async Task<OrderRequests?> Handle(CreateOrderRequestCommand requestCommand)
    {
        var order = new OrderRequests(requestCommand);
        await orderRequestRepository.AddAsync(order);
        await unitOfWOrk.CompleteAsync();
        return order;

    }
    
}
