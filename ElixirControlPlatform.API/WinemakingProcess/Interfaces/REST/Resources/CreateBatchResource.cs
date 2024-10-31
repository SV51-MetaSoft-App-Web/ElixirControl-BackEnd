namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record CreateBatchResource(
    string VineyardCode, 
    string GrapeVariety, 
    string HarvestDate, 
    int GrapeQuantity, 
    string VineyardOrigin, 
    string ProcessStartDate);