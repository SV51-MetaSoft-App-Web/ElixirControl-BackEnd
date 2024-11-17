using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;

namespace ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;

public class Inventory
{
    public int Id { get; private set; }

    //========================== Inventory Information ==========================
    
    public string Name { get; set; } 
    public string Type { get; set; } 
    public string Unit { get; set; } 
    public DateTime Expiration { get; set; } 
    public string Supplier { get; set; } 
    public decimal CostPerUnit { get; set; }
    public DateTime LastUpdated { get; private set; }
    public int Quantity { get; set; } 

    //======================== end Inventory Information ========================

    public Inventory()
    {
        this.Name = string.Empty;
        this.Type = string.Empty;
        this.Unit = string.Empty;
        this.Expiration = DateTime.MinValue;
        this.Supplier = string.Empty;
        this.CostPerUnit = 0m;
        this.LastUpdated = DateTime.Now;
        this.Quantity = 0;
    }
    
    public Inventory(string name, string type, string unit, DateTime expiration, string supplier, decimal costPerUnit, int quantity) : this()
    {
        Name = name;
        Type = type;
        Unit = unit;
        Expiration = expiration;
        Supplier = supplier;
        CostPerUnit = costPerUnit;
        Quantity = quantity;
        LastUpdated = DateTime.UtcNow; 
    }

    public Inventory(CreateInventoryCommand command) : this()
    {
        Name = command.Name;
        Type = command.Type;
        Unit = command.Unit;
        Expiration = command.Expiration;
        Supplier = command.Supplier;
        CostPerUnit = command.CostPerUnit;
        Quantity = command.Quantity;
        LastUpdated = DateTime.UtcNow; 
    }
}