using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        return new CreateOrderCommand(
            resource.OrderId,
            resource.Quantity,
            resource.Price,
            resource.Status,
            resource.OrderNumber,
            resource.OrderDate,
            resource.TransportCondition,
            resource.PaymentMethod,
            resource.ConsumerPhone,
            resource.ProducerPhone,
            resource.PaymentTerms,
            resource.Date,
            resource.DeliveryDate,
            resource.Type
        );
    }
}

