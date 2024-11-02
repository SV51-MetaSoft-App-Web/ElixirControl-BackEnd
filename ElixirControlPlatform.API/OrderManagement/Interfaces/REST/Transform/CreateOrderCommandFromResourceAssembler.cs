using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Resources;


namespace ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderSourceCommand ToCommandFromResource(CreateOrderResource resource)
    {
        return new CreateOrderSourceCommand(resource.BusinessName, resource.RequestedDate, resource.Quantity, resource.Phone, resource.Status, resource.ContactName, resource.ProductName, resource.TransportCondition, resource.PaymentTerms, resource.Address, resource.Email, resource.Ruc, resource.WineType, resource.PaymentMethod, resource.DeliveryDate);
    }
}