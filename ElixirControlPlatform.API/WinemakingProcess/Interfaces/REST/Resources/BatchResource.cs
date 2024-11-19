namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record BatchResource(
    int Id,
    Guid profileId,
    string VineyardCode, 
    string GrapeVariety, 
    string HarvestDate, 
    int GrapeQuantity, 
    string VineyardOrigin, 
    string ProcessStartDate);