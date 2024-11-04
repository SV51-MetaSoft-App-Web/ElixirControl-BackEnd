using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

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

    public CurrentBatchStatus Status { get; internal set; }

    //======================== end Batch Information ========================



    //============ Winemaking Process - Propiedad de navegación =============
    public Fermentation Fermentation { get; private set; }
    public Clarification Clarification { get; private set; }
    public Pressing Pressing { get; private set; }
    public Aging Aging { get; private set; }
    //=========== end Winemaking Process - Propiedad de navegación ==========


    public Batch()
    {
        this.Status = CurrentBatchStatus.Collected;
        this.VineyardCode = string.Empty;
        this.GrapeVariety = string.Empty;
        this.HarvestDate = string.Empty;
        this.GrapeQuantity = 0;
        this.VineyardOrigin = string.Empty;
        this.ProcessStartDate = string.Empty;

    }

    public Batch(string vineyardCode, string grapeVariety, string harvestDate, int grapeQuantity, string vineyardOrigin,
        string processStartDate) : this()
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
    
    
    //========================================================================
    //========================== Winemaking Process ==========================
    //========================================================================
    
    //============================= FERMENTATION =============================
    public void AddFermentationByBatch(int batchId, string startDate, string endDate, double averageTemperature,
        double initialDensity, double initialPh, double finalDensity, double finalPh, double residualSugar)
    {
        Fermentation = new Fermentation(batchId, startDate, endDate, averageTemperature, initialDensity, initialPh,
            finalDensity, finalPh, residualSugar);
        this.Status = CurrentBatchStatus.Fermentation;
    }
    
    public void DeleteFermentationByBatch()
    {
        Fermentation = null;
        this.Status = CurrentBatchStatus.Collected;
    }

    public void UpdateFermentationToBatch(int batchId, string startDate, string endDate, double averageTemperature,
        double initialDensity, double initialPh, double finalDensity, double finalPh, double residualSugar)
    {
        Fermentation = new Fermentation(batchId, startDate, endDate, averageTemperature, initialDensity, initialPh,
            finalDensity, finalPh, residualSugar);
    }
    //------------------------ end FERMENTATION ----------------------------

    //============================= CLARIFICATION =============================
    public void AddClarificationByBatch(int batchId, string productsUsed, string clarificationMethod,
        string filtrationDate, double clarityLevel, string startDate, string endDate)
    {
        Clarification = new Clarification(batchId, productsUsed, clarificationMethod, filtrationDate, clarityLevel,
            startDate, endDate);
        this.Status = CurrentBatchStatus.Clarification;
    }
    
    public void DeleteClarificationByBatch()
    {
        Clarification = null;
        this.Status = CurrentBatchStatus.Pressing;
    }
    
    public void UpdateClarificationByBatch(int batchId, string productsUsed, string clarificationMethod,
        string filtrationDate, double clarityLevel, string startDate, string endDate)
    {
        Clarification = new Clarification(batchId, productsUsed, clarificationMethod, filtrationDate, clarityLevel,
            startDate, endDate);
    }
    
    //------------------------ end Clarification ----------------------------

    //============================= PRESSING =============================
    public void AddPressingByBatch(int batchId, string pressingDate, double mustVolume, string pressType,
        double appliedPressure)
    {
        Pressing = new Pressing(batchId, pressingDate, mustVolume, pressType, appliedPressure);
        this.Status = CurrentBatchStatus.Pressing;
    }
    
    public void DeletePressingByBatch()
    {
        this.Pressing = null;
        this.Status = CurrentBatchStatus.Fermentation;
    }
    
    public void UpdatePressingToBatch(int batchId, string pressingDate, double mustVolume, string pressType,
        double appliedPressure)
    {
        Pressing = new Pressing(batchId, pressingDate, mustVolume, pressType, appliedPressure);
    }

    //------------------------ end Pressing ----------------------------

    
    //============================= AGING =============================
    public void AddAgingByBatch(int BatchId, string BarrelType, string StartDate, string EndDate, int AgingDurationMonths, int InspectionsPerformed, string InspectionResult)
    {
        Aging = new Aging(BatchId, BarrelType, StartDate, EndDate, AgingDurationMonths, InspectionsPerformed, InspectionResult);
        this.Status = CurrentBatchStatus.Aging;
    }
    
    public void DeleteAgingByBatch()
    {
        Aging = null;
        this.Status = CurrentBatchStatus.Clarification;
    }
    
    public void UpdateAgingByBatch(int BatchId, string BarrelType, string StartDate, string EndDate, int AgingDurationMonths, int InspectionsPerformed, string InspectionResult)
    {
        Aging = new Aging(BatchId, BarrelType, StartDate, EndDate, AgingDurationMonths, InspectionsPerformed, InspectionResult);
    }
    //------------------------ end Aging ----------------------------

    //========================================================================
    //======================== end Winemaking Process ========================
    //========================================================================

}