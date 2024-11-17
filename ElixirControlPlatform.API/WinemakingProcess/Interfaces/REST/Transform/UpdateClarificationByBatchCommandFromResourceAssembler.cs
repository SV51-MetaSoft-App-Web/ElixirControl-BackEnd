using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class UpdateClarificationByBatchCommandFromResourceAssembler
{
    public static UpdateClarificationByBatchCommand ToCommandFromResource(UpdateClarificationByBatchResource resource)
    {
        return new UpdateClarificationByBatchCommand(
            ProductsUsed: resource.ProductsUsed,
            ClarificationMethod: resource.ClarificationMethod,
            FiltrationDate: resource.FiltrationDate,
            ClarityLevel: resource.ClarityLevel,
            StartDate: resource.StartDate,
            EndDate: resource.EndDate
        );
    }
}
