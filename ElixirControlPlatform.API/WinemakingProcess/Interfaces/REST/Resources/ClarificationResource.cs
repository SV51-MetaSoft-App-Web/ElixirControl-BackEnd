namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record ClarificationResource(
    int Id,
    int BatchId, 
    string ProductsUsed, 
    string ClarificationMethod, 
    DateTime? FiltrationDate, 
    double ClarityLevel, 
    DateTime? StartDate,
    DateTime? EndDate);
