using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Queries;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Services;

/// <summary>
///  Order requests query service interface
/// </summary>

public interface IOrderRequestsQueryService
{   
    /// <summary>
    ///  Handle get all orders requests query
    /// </summary>
    /// <param name="requestsQuery"></param>
    /// <returns>
    /// The order requests if successful otherwise null
    /// </returns>
    
    Task<IEnumerable<OrderRequests>> Handle(GetAllOrdersRequestsQuery requestsQuery);
    
    Task<OrderRequests?> Handle(GetOrderRequestsByIdQuery query);
}