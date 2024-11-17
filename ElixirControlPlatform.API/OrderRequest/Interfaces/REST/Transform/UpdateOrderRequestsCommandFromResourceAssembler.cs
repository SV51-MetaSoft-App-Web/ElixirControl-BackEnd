using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Transform;

public static class UpdateOrderRequestsCommandFromResourceAssembler
{
    public static UpdateOrderRequestsStatusByIdCommand ToCommandFromResource(int id, UpdateOrderRequestsStatusByIdResource statusByIdResource)
    {
        return new UpdateOrderRequestsStatusByIdCommand(
            Id: id,
            Status: statusByIdResource.Status
        );
    }
}