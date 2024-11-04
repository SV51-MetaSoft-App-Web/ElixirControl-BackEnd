namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record UpdateClarificationByBatchResource(
    string ProductsUsed, 
    string ClarificationMethod, 
    string FiltrationDate, 
    double ClarityLevel, 
    string StartDate, 
    string EndDate);