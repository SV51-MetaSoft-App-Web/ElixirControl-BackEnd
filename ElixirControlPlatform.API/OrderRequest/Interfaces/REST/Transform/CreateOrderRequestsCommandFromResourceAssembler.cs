using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Transform;

public static class CreateOrderRequestsCommandFromResourceAssembler
{
    public static CreateOrderRequestsCommand ToCommandFromResource(CreateOrderRequestsResource resource)
    {
        return new CreateOrderRequestsCommand(
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

