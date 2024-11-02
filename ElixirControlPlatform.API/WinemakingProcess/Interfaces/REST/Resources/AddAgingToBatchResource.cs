namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddAgingToBatchResource(
    int BatchId, 
    string BarrelType, 
    string StartDate, 
    string EndDate, 
    int AgingDurationMonths, 
    int InspectionsPerformed, 
    string InspectionResult);