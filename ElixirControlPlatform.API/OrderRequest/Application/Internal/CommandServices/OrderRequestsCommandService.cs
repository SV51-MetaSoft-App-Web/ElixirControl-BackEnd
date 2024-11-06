using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Domain.Repositories;
using ElixirControlPlatform.API.OrderRequest.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.OrderRequest.Application.Internal.CommandServices;

public class OrderRequestsCommandService(IOrderRequestsRepository orderRequestsRepository, IUnitOfWOrk unitOfWOrk): IOrderRequestsCommandService
{
    public async Task<OrderRequests?> Handle(CreateOrderRequestsCommand requestsCommand)
    {
        var order = new OrderRequests(requestsCommand);
        await orderRequestsRepository.AddAsync(order);
        await unitOfWOrk.CompleteAsync();
        return order;

    }
    
}
