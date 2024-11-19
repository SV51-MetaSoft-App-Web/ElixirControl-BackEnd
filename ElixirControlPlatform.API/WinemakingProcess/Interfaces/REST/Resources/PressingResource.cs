namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record PressingResource(
    int Id,
    int BatchId, 
    string PressingDate, 
    double MustVolume, 
    string PressType, 
    double AppliedPressure);