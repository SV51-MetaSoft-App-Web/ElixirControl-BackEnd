using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Domain.Repositories;
using ElixirControlPlatform.API.OrderRequest.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.OrderRequest.Application.Internal.CommandServices;

/// <summary>
///     OrderRequests command service
/// </summary>
/// <param name="orderRequestsRepository"></param>
/// <param name="unitOfWOrk"></param>

public class OrderRequestsCommandService(IOrderRequestsRepository orderRequestsRepository, IUnitOfWOrk unitOfWOrk): IOrderRequestsCommandService
{
    public async Task<OrderRequests?> Handle(CreateOrderRequestsCommand command)
    {
        var orderRequests = await orderRequestsRepository.FindByOrderNumberAsync(command.OrderNumber);
        if (orderRequests != null) throw new Exception("Order Request with Order Number already exists");
        if (command.ConsumerPhone.Length != 9) throw new Exception("Consumer Phone must have 9 digits");
        if (command.ProducerPhone.Length != 9) throw new Exception("Producer Phone must have 9 digits");
        orderRequests = new OrderRequests(command);
        await orderRequestsRepository.AddAsync(orderRequests);
        await unitOfWOrk.CompleteAsync();
        return orderRequests;

    }
    public async Task<OrderRequests?> Handle(UpdateOrderRequestsStatusByIdCommand command)
    {
        var orderRequests = await orderRequestsRepository.FindByIdAsync(command.Id);
        if (orderRequests == null)
        {
            return null;
        }
        orderRequests.UpdateStatus(command);
        await unitOfWOrk.CompleteAsync();
        return orderRequests;
    }
    public async Task<OrderRequests?> Handle(DeleteOrderRequestsCommand command)
    {
        var orderRequests = await orderRequestsRepository.FindByIdAsync(command.Id);
        if (orderRequests == null) throw new Exception("Order Request not found");
        orderRequestsRepository.Remove(orderRequests);
        await unitOfWOrk.CompleteAsync();
        return orderRequests;
    }
    
    public async Task<OrderRequests?> Handle(UpdateOrderRequestsByIdCommand command)
    {
        var orderRequests = await orderRequestsRepository.FindByIdAsync(command.Id);
        if (orderRequests is null) throw new Exception("Order Request not found");
        var orderRequests2 = await orderRequestsRepository.FindByOrderNumberAsync(command.OrderNumber);
        if (orderRequests2 != null && orderRequests2.OrderNumber != command.OrderNumber) throw new Exception("Order Request with Order Number already exists");
        if (command.ConsumerPhone.Length != 9) throw new Exception("Consumer Phone must have 9 digits");
        if (command.ProducerPhone.Length != 9) throw new Exception("Producer Phone must have 9 digits");
        orderRequests.UpdateOrderRequestsById(command);
        orderRequestsRepository.Update(orderRequests);
        await unitOfWOrk.CompleteAsync();
        return orderRequests;
    }
}
