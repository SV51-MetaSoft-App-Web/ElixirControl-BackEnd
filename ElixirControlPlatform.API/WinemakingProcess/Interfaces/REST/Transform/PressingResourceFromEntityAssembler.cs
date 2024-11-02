using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class PressingResourceFromEntityAssembler
{
    public static PressingResource ToResourceFromEntity(Pressing entity)
    {
        return new PressingResource( 
            entity.Id, 
            entity.BatchId, 
            entity.PressingDate, 
            entity.MustVolume, 
            entity.PressType, 
            entity.AppliedPressure
        );
    }
    
}