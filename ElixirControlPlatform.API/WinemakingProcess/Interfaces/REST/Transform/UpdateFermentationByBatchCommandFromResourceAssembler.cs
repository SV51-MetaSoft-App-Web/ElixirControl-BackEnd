using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class UpdateFermentationByBatchCommandFromResourceAssembler
{
    public static UpdateFermentationByBatchCommand ToCommandFromResource(UpdateFermentationByBatchResource resource)
    {
       return new UpdateFermentationByBatchCommand(
            StartDate: resource.StartDate,
            EndDate: resource.EndDate,
            AverageTemperature: resource.AverageTemperature,
            InitialDensity: resource.InitialDensity,
            InitialPh: resource.InitialPh,
            FinalDensity: resource.FinalDensity,
            FinalPh: resource.FinalPh,
            ResidualSugar: resource.ResidualSugar
        );
    }
}