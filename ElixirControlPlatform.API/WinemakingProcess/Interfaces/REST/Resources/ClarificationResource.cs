namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record ClarificationResource(
    int Id,
    int BatchId, 
    string ProductsUsed, 
    string ClarificationMethod, 
    string FiltrationDate, 
    double ClarityLevel, 
    string StartDate,
    string EndDate);
