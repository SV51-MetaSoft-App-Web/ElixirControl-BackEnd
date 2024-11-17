using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
using ElixirControlPlatform.API.OrderManagement.Domain.Services;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;

namespace ElixirControlPlatform.API.OrderManagement.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository) : IOrderQueryService
{
    public async Task<Order?> Handle(GetOrderByIdQuery query)
    {
        return await orderRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Order>> Handle(GetAllOrdersByProfileId query)
    {
        return await orderRepository.GetAllOrdersByProfileId(query);
    }
}