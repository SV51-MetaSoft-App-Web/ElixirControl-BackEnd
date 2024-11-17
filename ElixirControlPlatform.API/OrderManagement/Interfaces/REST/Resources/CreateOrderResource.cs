namespace ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Resources;

/// <summary>
/// Resource to create an order
/// </summary>
/// param name="BusinessName">The name of the business</param>
/// param name="RequestedDate">The date the order was requested</param>
/// param name="Quantity">The quantity of the order</param>
/// param name="Phone">The phone number of the business</param>
/// param name="Status">The status of the order</param>
/// param name="ContactName">The name of the contact person</param>
/// param name="ProductName">The name of the product</param>
/// param name="TransportCondition">The transport condition of the order</param>
/// param name="PaymentTerms">The payment terms of the order</param>
/// param name="Address">The address of the business</param>
/// param name="Email">The email of the business</param>
/// param name="Ruc">The RUC of the business</param>
/// param name="WineType">The type of wine</param>
/// param name="PaymentMethod">The payment method</param>
/// param name="DeliveryDate">The delivery date of the order</param>

public record CreateOrderResource(string BusinessName, string RequestedDate, int Quantity, string Phone, string Status, string ContactName, string ProductName, string TransportCondition, string PaymentTerms, string Address, string Email, string Ruc, string WineType, string PaymentMethod, string DeliveryDate);