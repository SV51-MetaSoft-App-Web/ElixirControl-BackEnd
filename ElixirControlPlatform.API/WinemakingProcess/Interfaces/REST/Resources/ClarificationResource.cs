namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record ClarificationResource(
    int batchId, 
    string productsUsed, 
    string clarificationMethod, 
    string filtrationDate, 
    double clarityLevel, 
    string startDate,
    string endDate);
