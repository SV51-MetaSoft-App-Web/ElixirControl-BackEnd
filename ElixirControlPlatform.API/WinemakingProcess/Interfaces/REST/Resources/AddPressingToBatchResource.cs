namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddPressingToBatchResource(   
    string PressingDate, 
    double MustVolume, 
    string PressType, 
    double AppliedPressure);