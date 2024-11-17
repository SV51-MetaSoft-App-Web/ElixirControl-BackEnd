using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;

namespace ElixirControlPlatform.API.OrderManagement.Domain.Services;

/// <summary>
/// Order command service interface
/// </summary>

public interface IOrderCommandService
{
   
    public Task<Order?> Handle(CreateOrderCommand command, Guid profileId);
    public Task<Order?> Handle(UpdateOrderStatusCommand statusCommand);
    public Task<Order?> Handle(DeleteOrderCommand command);
}