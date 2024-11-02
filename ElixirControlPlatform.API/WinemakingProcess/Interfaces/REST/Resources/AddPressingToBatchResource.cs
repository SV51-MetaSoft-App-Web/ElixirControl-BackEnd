namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddPressingToBatchResource(   
    int BatchId, 
    string PressingDate, 
    double MustVolume, 
    string PressType, 
    double AppliedPressure);