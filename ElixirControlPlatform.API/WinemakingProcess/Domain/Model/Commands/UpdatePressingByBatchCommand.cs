namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

public record UpdatePressingByBatchCommand(
    string PressingDate, 
    double MustVolume, 
    string PressType, 
    double AppliedPressure);