namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

public record UpdateClarificationByBatchCommand(    
    string ProductsUsed, 
    string ClarificationMethod, 
    string FiltrationDate, 
    double ClarityLevel, 
    string StartDate, 
    string EndDate);