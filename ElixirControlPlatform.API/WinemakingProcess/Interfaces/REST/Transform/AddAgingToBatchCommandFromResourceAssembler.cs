using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class AddAgingToBatchCommandFromResourceAssembler
{
    public static AddAgingToBatchCommand ToCommandFromResource(AddAgingToBatchResource resource, int BatchId)
    {
        return new AddAgingToBatchCommand(
            BatchId: BatchId,
            BarrelType: resource.BarrelType,
            StartDate: resource.StartDate,
            EndDate: resource.EndDate,
            AgingDurationMonths: resource.AgingDurationMonths,
            InspectionsPerformed: resource.InspectionsPerformed,
            InspectionResult: resource.InspectionResult
        );
    }
}