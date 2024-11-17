using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class CreateBatchCommandFromResourceAssembler
{
    public static CreateBatchCommand ToCommandFromResource(CreateBatchResource resource)
    {
        return new CreateBatchCommand(
            resource.VineyardCode,
            resource.GrapeVariety,
            resource.HarvestDate,
            resource.GrapeQuantity,
            resource.VineyardOrigin,
            resource.ProcessStartDate
        );
    }
    
}