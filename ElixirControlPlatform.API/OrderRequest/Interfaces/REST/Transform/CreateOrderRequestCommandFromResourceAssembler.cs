using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Transform;

public static class CreateOrderRequestCommandFromResourceAssembler
{
    public static CreateOrderRequestCommand ToCommandFromResource(CreateOrderRequestResource requestResource)
    {
        return new CreateOrderRequestCommand(
            requestResource.Quantity,
            requestResource.Price,
            requestResource.Status,
            requestResource.OrderNumber,
            requestResource.OrderDate,
            requestResource.TransportCondition,
            requestResource.PaymentMethod,
            requestResource.ConsumerPhone,
            requestResource.ProducerPhone,
            requestResource.PaymentTerms,
            requestResource.Date,
            requestResource.DeliveryDate,
            requestResource.Type
        );
    }
}

