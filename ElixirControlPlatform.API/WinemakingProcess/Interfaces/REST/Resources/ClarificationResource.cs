namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record ClarificationResource(
    int      Id,
    int    batchId, 
    string productsUsed, 
    string clarificationMethod, 
    DateTime? filtrationDate, 
    double clarityLevel, 
    DateTime? startDate,
    DateTime? endDate);
