using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Resources;


namespace ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        return new CreateOrderCommand(resource.BusinessName, resource.RequestedDate, resource.Quantity, resource.Phone, "In Process", resource.ContactName, resource.ProductName, resource.TransportCondition, resource.PaymentTerms, resource.Address, resource.Email, resource.Ruc, resource.WineType, resource.PaymentMethod, resource.DeliveryDate);
    }
}