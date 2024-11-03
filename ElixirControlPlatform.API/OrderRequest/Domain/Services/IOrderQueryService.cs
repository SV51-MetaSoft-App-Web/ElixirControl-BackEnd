using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Queries;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<OrderRequests>> Handle(GetAllOrdersQuery query);
    
    Task<OrderRequests?> Handle(GetOrderByIdQuery query);
}