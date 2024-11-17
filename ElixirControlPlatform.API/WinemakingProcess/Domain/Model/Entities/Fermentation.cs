using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;

namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;

public partial class Fermentation
{
    public int Id { get; private set; }
    
    //========================== Fermentation Information ==========================
    public int BatchId { get; private set; }
    public string StartDate { get; private set; }
    public string EndDate { get; private set; }
    public double AverageTemperature { get; private set; }
    public double InitialDensity { get; private set; }
    public double InitialPh { get; private set; }
  
    
    public double FinalDensity { get; private set; }
    public double FinalPh { get; private set; }
    public double ResidualSugar { get; private set; }
    
    //======================== end Fermentation Information ========================
    
    public Fermentation()
    {
        this.BatchId = 0;
        this.StartDate = string.Empty;
        this.EndDate = string.Empty;
        this.AverageTemperature = 0;
        this.InitialDensity = 0;
        this.InitialPh = 0;
        this.FinalDensity = 0;
        this.FinalPh = 0;
        this.ResidualSugar = 0;
    }
    
    public Fermentation(int batchId, string startDate, string endDate, double averageTemperature, double initialDensity, double initialPh, double finalDensity, double finalPh, double residualSugar) : this()
    {
        BatchId = batchId;
        StartDate = startDate;
        EndDate = endDate;
        AverageTemperature = averageTemperature;
        InitialDensity = initialDensity;
        InitialPh = initialPh;
        FinalDensity = finalDensity;
        FinalPh = finalPh;
        ResidualSugar = residualSugar;
    }
    
}