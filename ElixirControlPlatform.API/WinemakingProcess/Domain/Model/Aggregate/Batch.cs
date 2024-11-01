using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;

namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;

public partial class Batch
{
    public int Id { get; private set; }

    //========================== Batch Information ==========================
    public string VineyardCode { get; private set; } 
    public string GrapeVariety { get; private set; } 
    public string HarvestDate { get; private set; } 
    public int GrapeQuantity { get; private set; } 
    public string VineyardOrigin { get; private set; } 
    public string ProcessStartDate { get; private set; }

    //======================== end Batch Information ========================
    
    
    
    //============ Winemaking Process - Propiedad de navegación =============
    public Fermentation Fermentation { get; private set; }
    //=========== end Winemaking Process - Propiedad de navegación ==========
    
    
    public Batch()
    {
        this.Fermentation = new Fermentation();
        this.VineyardCode = string.Empty;
        this.GrapeVariety = string.Empty;
        this.HarvestDate = string.Empty;
        this.GrapeQuantity = 0;
        this.VineyardOrigin = string.Empty;
        this.ProcessStartDate = string.Empty;
        
    }
    
    public Batch (string vineyardCode, string grapeVariety, string harvestDate, int grapeQuantity, string vineyardOrigin, string processStartDate) : this()
    {
        VineyardCode = vineyardCode;
        GrapeVariety = grapeVariety;
        HarvestDate = harvestDate;
        GrapeQuantity = grapeQuantity;
        VineyardOrigin = vineyardOrigin;
        ProcessStartDate = processStartDate;
    }
    
    public Batch(CreateBatchCommand command) : this()
    {
        VineyardCode = command.VineyardCode;
        GrapeVariety = command.GrapeVariety;
        HarvestDate = command.HarvestDate;
        GrapeQuantity = command.GrapeQuantity;
        VineyardOrigin = command.VineyardOrigin;
        ProcessStartDate = command.ProcessStartDate;
    }
    
    public void AddFermentationToBatch(int batchId, string startDate, string endDate, double averageTemperature, double initialDensity, double initialPh, double finalDensity, double finalPh, double residualSugar)
    {
        Fermentation = new Fermentation(batchId, startDate, endDate, averageTemperature, initialDensity, initialPh, finalDensity, finalPh, residualSugar);
    }
    
    
    
}