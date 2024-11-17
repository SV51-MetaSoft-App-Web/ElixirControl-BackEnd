using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class AgingResourceFromEntityAssembler
{
    public static AgingResource ToResourceFromEntity(Aging entity)
    {
        return new AgingResource(
            entity.Id,
            entity.BatchId,
            entity.BarrelType,
            entity.StartDate,
            entity.EndDate,
            entity.AgingDurationMonths,
            entity.InspectionsPerformed,
            entity.InspectionResult
        );
    }
}