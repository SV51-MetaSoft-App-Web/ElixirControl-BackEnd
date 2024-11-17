namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddClarificationToBatchCommand(
    string ProductsUsed, 
    string ClarificationMethod, 
    string FiltrationDate, 
    double ClarityLevel, 
    string StartDate, 
    string EndDate);