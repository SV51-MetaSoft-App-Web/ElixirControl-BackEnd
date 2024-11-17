namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record PressingResource(
    int Id,
    int BatchId, 
    DateTime? PressingDate, 
    double MustVolume, 
    string PressType, 
    double AppliedPressure);