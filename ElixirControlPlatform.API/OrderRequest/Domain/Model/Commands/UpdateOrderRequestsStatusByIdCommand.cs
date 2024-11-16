namespace ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;

public record UpdateOrderRequestsStatusByIdCommand(
    int Id,
    string Status);