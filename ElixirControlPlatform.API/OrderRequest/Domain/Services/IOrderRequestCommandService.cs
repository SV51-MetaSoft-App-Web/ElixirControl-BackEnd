using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Services;

public interface IOrderRequestCommandService
{
    public Task<OrderRequests?> Handle(CreateOrderRequestCommand requestCommand);
}
