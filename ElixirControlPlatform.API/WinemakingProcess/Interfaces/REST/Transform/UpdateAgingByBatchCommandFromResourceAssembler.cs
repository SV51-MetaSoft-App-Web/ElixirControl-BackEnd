using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class UpdateAgingByBatchCommandFromResourceAssembler
{
    public static UpdateAgingByBatchCommand ToCommandFromResource(UpdateAgingByBatchResource resource)
    {
        return new UpdateAgingByBatchCommand(
            BarrelType: resource.BarrelType,
            StartDate: resource.StartDate,
            EndDate: resource.EndDate,
            AgingDurationMonths: resource.AgingDurationMonths,
            InspectionsPerformed: resource.InspectionsPerformed,
            InspectionResult: resource.InspectionResult
        );
    }
}



