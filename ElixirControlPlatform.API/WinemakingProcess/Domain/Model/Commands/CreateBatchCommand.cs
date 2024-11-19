namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;


public record CreateBatchCommand(
    string VineyardCode, 
    string GrapeVariety, 
    string HarvestDate, 
    int GrapeQuantity, 
    string VineyardOrigin, 
    string ProcessStartDate
    );