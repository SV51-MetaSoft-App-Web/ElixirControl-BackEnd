namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;

public class Aging
{
    public int Id { get; private set; }
    public int BatchId { get; private set; }
    
    public string BarrelType { get; private set; }
    public int AgingDurationMonths { get; private set; }
    public int InspectionsPerformed { get; private set; }
    public string InspectionsResult { get; private set; }
    
    public string StartDate   { get; private set; }
    public string EndDate { get; private set; }

    protected Aging()
    {
        this.BarrelType = string.Empty;
        this.AgingDurationMonths = 0;
        this.InspectionsPerformed = 0;
        this.InspectionsResult = string.Empty;
        this.StartDate = string.Empty;
        this.EndDate = string.Empty;
    }
    
    
    
}


