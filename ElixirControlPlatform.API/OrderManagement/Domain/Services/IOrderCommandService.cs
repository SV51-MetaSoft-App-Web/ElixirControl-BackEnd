using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;

namespace ElixirControlPlatform.API.OrderManagement.Domain.Services;

/// <summary>
/// Order command service interface
/// </summary>

public interface IOrderCommandService
{
    /// <summary>
    /// Handle create order command
    /// </summary>
    /// <param name="sourceCommand"></param>
    /// <returns>
    /// The created order if successful otherwise null
    /// </returns>
    Task<Order?> Handle(CreateOrderSourceCommand sourceCommand);
}