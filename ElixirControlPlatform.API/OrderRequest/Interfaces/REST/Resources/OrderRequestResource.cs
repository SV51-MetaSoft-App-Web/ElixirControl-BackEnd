namespace ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Resources;

public record OrderRequestResource(
    int Id,
    int Quantity,
    int Price,
    string Status,
    string OrderNumber,
    string OrderDate,
    string TransportCondition,
    string PaymentMethod,
    string ConsumerPhone,
    string ProducerPhone,
    string PaymentTerms,
    string Date,
    string DeliveryDate,
    string Type
    
    );