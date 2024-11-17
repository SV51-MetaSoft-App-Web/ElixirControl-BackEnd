namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;

public class Aging
{
    public int Id { get; set; }
    
    //========================== Aging Information ==========================
    public int BatchId { get; private set; }
    public string BarrelType { get; private set; }
    public DateTime?  StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public int AgingDurationMonths { get; private set; }
    public int InspectionsPerformed { get; private set; }
    public string InspectionResult { get; private set; }
    //======================== end Aging Information ========================
    

    public Aging()
    {
        this.BatchId = 0;
        this.BarrelType = string.Empty;
        this.StartDate = null;
        this.EndDate = null;
        this.AgingDurationMonths = 0;
        this.InspectionsPerformed = 0;
        this.InspectionResult = string.Empty;
    }
    
    public Aging(int batchId, string barrelType, string startDate, string endDate, int agingDurationMonths, int inspectionsPerformed, string inspectionResult) : this()
    {
        BatchId = batchId;
        BarrelType = barrelType;
        StartDate = ConvertToDate(startDate);
        EndDate = ConvertToDate(endDate);
        AgingDurationMonths = agingDurationMonths;
        InspectionsPerformed = inspectionsPerformed;
        InspectionResult = inspectionResult;
    }
    
    
    private static DateTime? ConvertToDate(string date)
    {
        if (DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
        {
            return parsedDate;
        }
        return null;
    }
    
}