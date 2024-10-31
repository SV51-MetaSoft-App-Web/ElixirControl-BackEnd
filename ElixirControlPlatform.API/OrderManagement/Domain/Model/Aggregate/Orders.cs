namespace ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
///Orders aggregate
/// <summary>
/// This class represents the Orders aggregate. It is used to store the information of the orders.
/// </summary>
public class Orders
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
    public string ContactName {get; private set;}
    public string Address {get; private set;}
    public string Email {get; private set;}
    public string Ruc {get; private set;}
    public string WineType {get; private set;}
    public string paymentMethod {get; private set;}
    public string DeliveryDate {get; private set;}
    
    protected Orders()
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
        this.paymentMethod = string.Empty;
        this.DeliveryDate = string.Empty;
    }
    
    /// <summary>
    /// Constructor of the Orders aggregate
    /// </summary>
    /// <remarks>
    /// This constructor is the command handle for the CreateOrdersCommand.
    /// </remarks>
    /// <param name="command"></param>
    public Orders(CreateOrdersCommand command)
    {
        this.BusinessName = command.BusinessName;
        this.RequestedDate = command.RequestedDate;
        this.Quantity = command.Quantity;
        this.Phone = command.Phone;
        this.Status = command.Status;
        this.ContactName = command.ContactName;
        this.ProductName = command.ProductName;
        this.TransportCondition = command.TransportCondition;
        this.PaymentTerms = command.PaymentTerms;
        this.ContactName = command.ContactName;
        this.Address = command.Address;
        this.Email = command.Email;
        this.Ruc = command.Ruc;
        this.WineType = command.WineType;
        this.paymentMethod = command.paymentMethod;
        this.DeliveryDate = command.DeliveryDate;
    }
}