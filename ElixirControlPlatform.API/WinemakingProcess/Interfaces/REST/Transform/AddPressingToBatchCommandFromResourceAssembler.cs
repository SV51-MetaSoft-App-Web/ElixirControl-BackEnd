using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class AddPressingToBatchCommandFromResourceAssembler
{
    public static AddPressingToBatchCommand ToCommandFromResource(AddPressingToBatchResource resource, int BatchId)
    {
        return new AddPressingToBatchCommand(
            BatchId: BatchId,
            PressingDate: resource.PressingDate,
            MustVolume: resource.MustVolume,
            PressType: resource.PressType,
            AppliedPressure: resource.AppliedPressure
        );
    }
}