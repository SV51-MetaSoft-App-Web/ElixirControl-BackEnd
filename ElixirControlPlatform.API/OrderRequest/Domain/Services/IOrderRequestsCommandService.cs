using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Services;

/// <summary>
/// Order requests command service interface
/// </summary>

public interface IOrderRequestsCommandService
{   
    /// <summary>
    ///  Handle create order requests command
    /// </summary>
    /// <param name="command"></param>
    /// <returns>
    /// The created order requests if successful otherwise null
    /// </returns>
    public Task<OrderRequests?> Handle(CreateOrderRequestsCommand command);
    public Task<OrderRequests?> Handle(UpdateOrderRequestsStatusByIdCommand command);
    public Task<OrderRequests?> Handle(DeleteOrderRequestsCommand command);
    public Task<OrderRequests?> Handle(UpdateOrderRequestsByIdCommand command);
    
}
