namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddFermentationToBatchCommand(
    int BatchId, 
    string StartDate, 
    string EndDate, 
    double AverageTemperature, 
    double InitialDensity, 
    double InitialPh, 
    double FinalDensity, 
    double FinalPh, 
    double ResidualSugar);
