using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class AddClarificationToBatchCommandFromResourceAssembler
{
    public static AddClarificationToBatchCommand ToCommandFromResource(AddClarificationToBatchResource resource)
    {
        return new AddClarificationToBatchCommand(
            ProductsUsed: resource.ProductsUsed,
            ClarificationMethod: resource.ClarificationMethod,
            FiltrationDate: resource.FiltrationDate,
            ClarityLevel: resource.ClarityLevel,
            StartDate: resource.StartDate,
            EndDate: resource.EndDate
        );
    }
}