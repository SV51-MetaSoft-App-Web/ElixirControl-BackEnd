using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class BatchResourceFromEntityAssembler
{
    public static BatchResource ToResourceFromEntity(Batch entity)
    {
        return new BatchResource(
            entity.Id,
            entity.ProfileId,
            entity.VineyardCode,
            entity.GrapeVariety,
            entity.HarvestDate,
            entity.GrapeQuantity,
            entity.VineyardOrigin,
            entity.ProcessStartDate
        );
    }

}