using ElixirControlPlatform.API.ProductManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.Profiles.Domain.Model.Aggregate;

namespace ElixirControlPlatform.API.ProductManagement.Domain.Model.Aggregate;

public class Product
{
    
    int Id { get; set; }
    
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
    
    //=========== Information by product ===========
    
    public string NameProduct { get; set; }
    public string GrapeVariety { get; set; }
    public string WineType { get; set; }
    public string Origin { get; set; }
    public double? AlcoholContent { get; set; }
    public double? Price { get; set; }
    public string FoodPairing { get; set; }
    public int? Quantity { get; set; }
    public string Image { get; set; }

    public Product()
    {
        this.NameProduct = string.Empty;
        this.GrapeVariety = string.Empty;
        this.WineType = string.Empty;
        this.Origin = string.Empty;
        this.AlcoholContent = null;
        this.Price = null;
        this.FoodPairing = string.Empty;
        this.Quantity = null;
        this.Image = string.Empty;
    }

    public Product(CreateProductCommand command)
    {
        this.NameProduct = command.NameProduct;
        this.GrapeVariety = command.GrapeVariety;
        this.WineType = command.WineType;
        this.Origin = command.Origin;
        this.AlcoholContent = command.AlcoholContent;
        this.Price = command.Price;
        this.FoodPairing = command.FoodPairing;
        this.Quantity = command.Quantity;
        this.Image = command.Image;

    }




    

}