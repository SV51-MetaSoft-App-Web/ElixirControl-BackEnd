using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.OrderRequest.Interfaces.REST.Transform;

public static class OrderRequestResourceFromEntityAssembler
{
    public static OrderRequestResource ToResourceFromEntity(OrderRequests entity)
    {
        return new OrderRequestResource(
            entity.Id,
            entity.Quantity,
            entity.Price,
            entity.Status,
            entity.OrderNumber,
            entity.OrderDate,
            entity.TransportCondition,
            entity.PaymentMethod,
            entity.ConsumerPhone,
            entity.ProducerPhone,
            entity.PaymentTerms,
            entity.Date,
            entity.DeliveryDate,
            entity.Type
            
        );
    }
    
}