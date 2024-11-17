namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddPressingToBatchCommand(
    string PressingDate, 
    double MustVolume, 
    string PressType, 
    double AppliedPressure);