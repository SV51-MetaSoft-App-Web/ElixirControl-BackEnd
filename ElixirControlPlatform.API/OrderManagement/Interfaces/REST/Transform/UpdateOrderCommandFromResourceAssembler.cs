using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Transform;

public static class UpdateOrderCommandFromResourceAssembler
{
    public static UpdateOrderStatusCommand ToCommandFromResource(int id, UpdateOrderResource resource)
    {
        return new UpdateOrderStatusCommand(
            id,
            resource.Status
        );
    }
}