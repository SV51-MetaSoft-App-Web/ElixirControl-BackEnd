using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Resources;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;


namespace ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Transform;

public class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order entity)
    {
        return new OrderResource(entity.Id,  entity.BusinessName, entity.RequestedDate, entity.Quantity, entity.Phone, entity.Status, entity.ContactName, entity.ProductName, entity.TransportCondition, entity.PaymentTerms, entity.Address, entity.Email, entity.Ruc, entity.WineType, entity.PaymentMethod, entity.DeliveryDate);
    } 
}