using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Queries;
using ElixirControlPlatform.API.OrderRequest.Domain.Repositories;
using ElixirControlPlatform.API.OrderRequest.Domain.Services;

namespace ElixirControlPlatform.API.OrderRequest.Application.Internal.QueryServices;

public class OrderRequestsQueryService(IOrderRequestsRepository orderRequestsRepository) : IOrderRequestsQueryService
{
    public async Task<OrderRequests?> Handle(GetOrderRequestsByIdQuery query)
    {
        return await orderRequestsRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<OrderRequests>> Handle(GetAllOrdersRequestsQuery requestsQuery)
    {
        return await orderRequestsRepository.ListAsync();
    }
}