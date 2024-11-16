using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Infrastructure.Persistence.EFC.Repositories;


namespace ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
///Order aggregate
/// <summary>
/// This class represents the Order aggregate. It is used to store the information of the order.
/// </summary>
public class Order
{
    public int Id { get; private set; }
    public string BusinessName {get ; private set;}
    public string RequestedDate{get; private set;}
    public int Quantity {get; private set;}
    public string Phone {get; private set;}
    public string Status {get; private set;}
    public string ContactName {get; private set;}
    public string ProductName {get; private set;}
    public string TransportCondition {get; private set;}
    public string PaymentTerms {get; private set;}
    public string Address {get; private set;}
    public string Email {get; private set;}
    public string Ruc {get; private set;}
    public string WineType {get; private set;}
    public string PaymentMethod {get; private set;}
    public string DeliveryDate {get; private set;}
    
    protected Order()
    {
        this.BusinessName = string.Empty;
        this.RequestedDate = string.Empty;
        this.Quantity = 0;
        this.Phone = string.Empty;
        this.Status = string.Empty;
        this.ContactName = string.Empty;
        this.ProductName = string.Empty;
        this.TransportCondition = string.Empty;
        this.PaymentTerms = string.Empty;
        this.ContactName = string.Empty;
        this.Address = string.Empty;
        this.Email = string.Empty;
        this.Ruc = string.Empty;
        this.WineType = string.Empty;
        this.PaymentMethod = string.Empty;
        this.DeliveryDate = string.Empty;
    }
    
    /// <summary>
    /// Constructor of the Orders aggregate
    /// </summary>
    /// <remarks>
    /// This constructor is the command handle for the CreateOrdersCommand.
    /// </remarks>
    /// <param name="command"></param>
    public Order(CreateOrderCommand command)
    {
        this.BusinessName = command.BusinessName;
        this.RequestedDate = command.RequestedDate;
        this.Quantity = command.Quantity;
        this.Phone = command.Phone;
        this.Status = "In Process";
        this.ContactName = command.ContactName;
        this.ProductName = command.ProductName;
        this.TransportCondition = command.TransportCondition;
        this.PaymentTerms = command.PaymentTerms;
        this.ContactName = command.ContactName;
        this.Address = command.Address;
        this.Email = command.Email;
        this.Ruc = command.Ruc;
        this.WineType = command.WineType;
        this.PaymentMethod = command.PaymentMethod;
        this.DeliveryDate = command.DeliveryDate;
    }
    
    public void UpdateStatus(UpdateOrderStatusCommand command)
    {
       this.Status = command.Status;
    }
    

}