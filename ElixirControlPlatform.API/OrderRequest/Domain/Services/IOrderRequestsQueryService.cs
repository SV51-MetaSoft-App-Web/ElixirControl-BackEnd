using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Queries;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Services;

public interface IOrderRequestsQueryService
{
    Task<IEnumerable<OrderRequests>> Handle(GetAllOrdersRequestsQuery requestsQuery);
    
    Task<OrderRequests?> Handle(GetOrderRequestsByIdQuery query);
}