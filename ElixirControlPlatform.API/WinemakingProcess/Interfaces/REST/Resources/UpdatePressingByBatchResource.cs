namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record UpdatePressingByBatchResource(
    string PressingDate, 
    double MustVolume, 
    string PressType, 
    double AppliedPressure);