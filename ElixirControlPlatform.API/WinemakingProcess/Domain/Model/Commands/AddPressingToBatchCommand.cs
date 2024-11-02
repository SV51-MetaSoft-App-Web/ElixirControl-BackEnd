namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddPressingToBatchCommand(
    int BatchId, 
    string PressingDate, 
    double MustVolume, 
    string PressType, 
    double AppliedPressure);