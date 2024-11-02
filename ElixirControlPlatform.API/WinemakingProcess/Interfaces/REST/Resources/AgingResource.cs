namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AgingResource(
    int Id,
    int BatchId, 
    string BarrelType, 
    DateTime? StartDate, 
    DateTime? EndDate, 
    int AgingDurationMonths, 
    int InspectionsPerformed, 
    string InspectionResult);