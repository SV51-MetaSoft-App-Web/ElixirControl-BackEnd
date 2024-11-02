using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Services;

public interface IOrderCommandService
{
    public Task<Order> Handle(CreateOrderCommand command);
}