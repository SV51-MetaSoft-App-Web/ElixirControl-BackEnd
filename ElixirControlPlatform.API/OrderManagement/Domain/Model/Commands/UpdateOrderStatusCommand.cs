namespace ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;

public record UpdateOrderStatusCommand(int Id, String Status);