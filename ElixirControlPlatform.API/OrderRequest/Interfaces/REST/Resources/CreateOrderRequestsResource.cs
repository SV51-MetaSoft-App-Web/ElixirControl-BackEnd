namespace ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Resources;

/// <summary>
///  Resource to create an order request
/// </summary>
/// <param name="Quantity"></param>
/// <param name="Price"></param>
/// <param name="Status"></param>
/// <param name="OrderNumber"></param>
/// <param name="OrderDate"></param>
/// <param name="TransportCondition"></param>
/// <param name="PaymentMethod"></param>
/// <param name="ConsumerPhone"></param>
/// <param name="ProducerPhone"></param>
/// <param name="PaymentTerms"></param>
/// <param name="Date"></param>
/// <param name="DeliveryDate"></param>
/// <param name="Type"></param>

public record CreateOrderRequestsResource(
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