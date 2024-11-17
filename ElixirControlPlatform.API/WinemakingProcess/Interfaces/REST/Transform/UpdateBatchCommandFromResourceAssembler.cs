using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class UpdateBatchCommandFromResourceAssembler
{
    public static UpdateBatchCommand ToCommandFromResource(UpdateBatchResource resource)
    {
        return new UpdateBatchCommand(
            VineyardCode: resource.VineyardCode,
            GrapeVariety: resource.GrapeVariety,
            HarvestDate: resource.HarvestDate,
            GrapeQuantity: resource.GrapeQuantity,
            VineyardOrigin: resource.VineyardOrigin,
            ProcessStartDate: resource.ProcessStartDate
        );
    }
}