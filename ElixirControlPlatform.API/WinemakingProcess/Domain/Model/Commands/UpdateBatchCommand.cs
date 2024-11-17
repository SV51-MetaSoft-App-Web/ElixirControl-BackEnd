namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

public record UpdateBatchCommand(
    string VineyardCode, 
    string GrapeVariety,
    string HarvestDate, 
    int GrapeQuantity, 
    string VineyardOrigin, 
    string ProcessStartDate);