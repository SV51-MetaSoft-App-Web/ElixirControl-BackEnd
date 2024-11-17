namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record UpdateBatchResource(
    string VineyardCode,
    string GrapeVariety,
    string HarvestDate,
    int GrapeQuantity,
    string VineyardOrigin,
    string ProcessStartDate
);