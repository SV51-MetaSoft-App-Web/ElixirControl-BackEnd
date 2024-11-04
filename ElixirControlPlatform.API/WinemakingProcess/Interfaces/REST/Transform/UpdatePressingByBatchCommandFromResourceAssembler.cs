using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class UpdatePressingByBatchCommandFromResourceAssembler
{
    public static UpdatePressingByBatchCommand ToCommandFromResource(UpdatePressingByBatchResource resource)
    {
        return new UpdatePressingByBatchCommand(
            PressingDate: resource.PressingDate,
            MustVolume: resource.MustVolume,
            PressType: resource.PressType,
            AppliedPressure: resource.AppliedPressure
        );
    }
    
}