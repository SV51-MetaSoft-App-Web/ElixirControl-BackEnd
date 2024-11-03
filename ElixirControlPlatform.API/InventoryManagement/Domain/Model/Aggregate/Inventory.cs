using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Commands;

namespace ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;

public class Inventory
{
    public int Id { get; private set; }

    //========================== Inventory Information ==========================
    
    public string Name { get; private set; } 
    public string Type { get; private set; } 
    public string Unit { get; private set; } 
    public DateTime Expiration { get; private set; } 
    public string Supplier { get; private set; } 
    public decimal CostPerUnit { get; private set; }
    public DateTime LastUpdated { get; private set; }
    public int Quantity { get; private set; } 

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
    
    public Inventory(int id, string name, string type, string unit, DateTime expiration, string supplier, decimal costPerUnit, DateTime lastUpdated, int quantity) : this()
    {
        Id = id;
        Name = name;
        Type = type;
        Unit = unit;
        Expiration = expiration;
        Supplier = supplier;
        CostPerUnit = costPerUnit;
        LastUpdated = lastUpdated;
        Quantity = quantity;
    }
    
    public Inventory(CreateInventoryCommand command) : this()
    {
        Id = command.Id; 
        Name = command.Name;
        Type = command.Type;
        Unit = command.Unit;
        Expiration = command.Expiration;
        Supplier = command.Supplier;
        CostPerUnit = command.CostPerUnit;
        LastUpdated = DateTime.Now; // Asignar la fecha y hora actual
        Quantity = command.Quantity;
    }
}