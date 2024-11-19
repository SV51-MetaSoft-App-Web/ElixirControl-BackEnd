namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;

public class Aging
{
    public int Id { get; set; }
    
    //========================== Aging Information ==========================
    public int BatchId { get; private set; }
    public string BarrelType { get; private set; }
    public string  StartDate { get; private set; }
    public string EndDate { get; private set; }
    public int AgingDurationMonths { get; private set; }
    public int InspectionsPerformed { get; private set; }
    public string InspectionResult { get; private set; }
    //======================== end Aging Information ========================
    

    public Aging()
    {
        this.BatchId = 0;
        this.BarrelType = string.Empty;
        this.StartDate = string.Empty;
        this.EndDate = string.Empty;
        this.AgingDurationMonths = 0;
        this.InspectionsPerformed = 0;
        this.InspectionResult = string.Empty;
    }
    
    public Aging(int batchId, string barrelType, string startDate, string endDate, int agingDurationMonths, int inspectionsPerformed, string inspectionResult) : this()
    {
        BatchId = batchId;
        BarrelType = barrelType;
        StartDate = startDate;
        EndDate = endDate;
        AgingDurationMonths = agingDurationMonths;
        InspectionsPerformed = inspectionsPerformed;
        InspectionResult = inspectionResult;
    }
    
}