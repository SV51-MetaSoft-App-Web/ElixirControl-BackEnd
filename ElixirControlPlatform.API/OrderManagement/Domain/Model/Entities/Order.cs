namespace ElixirControlPlatform.API.OrderManagement.Domain.Model.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public DateTime RequestedDate { get; set; }
        public int Quantity { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string ContactName { get; set; }
        public string ProductName { get; set; }
        public string TransportCondition { get; set; }
        public string PaymentTerms { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Ruc { get; set; }
        public string WineType { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
    
    public Order() {
    
    }
}