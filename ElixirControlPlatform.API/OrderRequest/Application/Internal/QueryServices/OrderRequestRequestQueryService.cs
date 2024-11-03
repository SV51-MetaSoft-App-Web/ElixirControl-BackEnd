using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Queries;
using ElixirControlPlatform.API.OrderRequest.Domain.Repositories;
using ElixirControlPlatform.API.OrderRequest.Domain.Services;

namespace ElixirControlPlatform.API.OrderRequest.Application.Internal.QueryServices;

public class OrderRequestRequestQueryService(IOrderRequestRepository orderRequestRepository) : IOrderRequestQueryService
{
    public async Task<OrderRequests?> Handle(GetOrderRequestByIdQuery query)
    {
        return await orderRequestRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<OrderRequests>> Handle(GetAllOrdersRequestQuery requestQuery)
    {
        return await orderRequestRepository.ListAsync();
    }
}