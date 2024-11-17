namespace ElixirControlPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record UpdateInventoryResource(
    
string Name,
string Type ,
string Unit, 
DateTime Expiration,
string Supplier, 
decimal CostPerUnit, 
int Quantity);