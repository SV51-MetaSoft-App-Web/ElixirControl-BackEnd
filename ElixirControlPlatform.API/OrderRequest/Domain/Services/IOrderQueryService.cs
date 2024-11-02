using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Queries;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    
    Task<Order?> Handle(GetOrderByIdQuery query);
}