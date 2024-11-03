using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderRequest.Domain.Model.ValueObjects;
using Microsoft.OpenApi.Services;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;

public class OrderRequests
{
    public int Id { get; private set;}
    
    public int Quantity { get; private set; }
    public int Price { get; private set; }
    public string Status { get; private set; }
    public string OrderNumber  { get; private set; }
    public string OrderDate { get; private set; }
        
    // Additional fields
    public string TransportCondition { get; private set; }
    public string PaymentMethod { get; private set; }
    public string ConsumerPhone { get; private set; }
    public string ProducerPhone { get; private set; }
    public string PaymentTerms { get; private set; }
    public string Date { get; private set; }
    public string DeliveryDate { get; private set; }
    public string Type { get; private set; }

    public OrderRequests()
    {
        this.Quantity = 0;
        this.Price = 0;
        this.Status = string.Empty;
        this.OrderNumber = string.Empty;
        this.OrderDate = string.Empty;
        this.TransportCondition = string.Empty;
        this.PaymentMethod = string.Empty;
        this.ConsumerPhone = string.Empty;
        this.ProducerPhone = string.Empty;
        this.PaymentTerms = string.Empty;
        this.Date = string.Empty;
        this.DeliveryDate = string.Empty;
        this.Type = string.Empty;
        
    }

    public OrderRequests(CreateOrderRequestCommand requestCommand) : this()
    {
        Quantity = requestCommand.Quantity;
        Price = requestCommand.Price;
        Status = requestCommand.Status;
        OrderNumber = requestCommand.OrderNumber;
        OrderDate = requestCommand.OrderDate;
        TransportCondition = requestCommand.TransportCondition;
        PaymentMethod = requestCommand.PaymentMethod;
        ConsumerPhone = requestCommand.ConsumerPhone;
        ProducerPhone = requestCommand.ProducerPhone;
        PaymentTerms = requestCommand.PaymentTerms;
        Date = requestCommand.Date;
        DeliveryDate = requestCommand.DeliveryDate;
        Type = requestCommand.Type;
    }    
}