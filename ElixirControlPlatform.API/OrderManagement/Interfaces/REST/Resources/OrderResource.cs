namespace ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Resources;


public record OrderResource(int Id, string BusinessName, string RequestedDate, int Quantity, string Phone, string Status, string ContactName, string ProductName, string TransportCondition, string PaymentTerms, string Address, string Email, string Ruc, string WineType, string PaymentMethod, string DeliveryDate);