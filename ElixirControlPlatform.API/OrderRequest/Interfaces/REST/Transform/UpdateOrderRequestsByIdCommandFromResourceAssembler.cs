using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Transform;

public static class UpdateOrderRequestsByIdCommandFromResourceAssembler
{
    public static UpdateOrderRequestsByIdCommand ToCommandFromResource(int id, UpdateOrderRequestsByIdResource resource)
    {
        return new UpdateOrderRequestsByIdCommand(
            Id: id,
            Quantity: resource.Quantity,
            Price: resource.Price,
            Status: resource.Status,
            OrderNumber: resource.OrderNumber,
            OrderDate: resource.OrderDate,
            TransportCondition: resource.TransportCondition,
            PaymentMethod: resource.PaymentMethod,
            ConsumerPhone: resource.ConsumerPhone,
            ProducerPhone: resource.ProducerPhone,
            PaymentTerms: resource.PaymentTerms,
            Date: resource.Date,
            DeliveryDate: resource.DeliveryDate,
            Type: resource.Type
        );
    }
}