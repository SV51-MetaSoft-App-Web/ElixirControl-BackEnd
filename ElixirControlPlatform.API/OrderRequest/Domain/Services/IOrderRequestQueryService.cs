using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Queries;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Services;

public interface IOrderRequestQueryService
{
    Task<IEnumerable<OrderRequests>> Handle(GetAllOrdersRequestQuery requestQuery);
    
    Task<OrderRequests?> Handle(GetOrderRequestByIdQuery query);
}