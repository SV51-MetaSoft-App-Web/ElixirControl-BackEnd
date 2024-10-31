using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;


namespace ElixirControlPlatform.API.OrderManagement.Domain.Services;

/// <summary>
/// Order command service interface
/// </summary>

public interface IOrderCommandService
{
    /// <summary>
    /// Handle create order command
    /// </summary>
    /// <param name="command"></param>
    /// <returns>
    /// The created order if successful otherwise null
    /// </returns>
    Task<Orders?> Handle(CreateOrderCommand command);
}