namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AgingResource(
    int Id,
    int BatchId, 
    string BarrelType, 
    string StartDate, 
    string EndDate, 
    int AgingDurationMonths, 
    int InspectionsPerformed, 
    string InspectionResult);