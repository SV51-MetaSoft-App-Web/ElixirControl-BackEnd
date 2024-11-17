using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class AddAgingToBatchCommandFromResourceAssembler
{
    public static AddAgingToBatchCommand ToCommandFromResource(AddAgingToBatchResource resource)
    {
        return new AddAgingToBatchCommand(
            BarrelType: resource.BarrelType,
            StartDate: resource.StartDate,
            EndDate: resource.EndDate,
            AgingDurationMonths: resource.AgingDurationMonths,
            InspectionsPerformed: resource.InspectionsPerformed,
            InspectionResult: resource.InspectionResult
        );
    }
}