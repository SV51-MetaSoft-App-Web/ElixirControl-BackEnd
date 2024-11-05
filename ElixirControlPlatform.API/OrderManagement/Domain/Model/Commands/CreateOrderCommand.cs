namespace ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;

public record CreateOrderCommand(string BusinessName, string RequestedDate, int Quantity, string Phone, string Status, string ContactName, string ProductName, string TransportCondition, string PaymentTerms, string Address, string Email, string Ruc, string WineType, string PaymentMethod, string DeliveryDate);