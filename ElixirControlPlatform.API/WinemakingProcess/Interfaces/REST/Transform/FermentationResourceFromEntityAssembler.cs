using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class FermentationResourceFromEntityAssembler
{
    
    public static FermentationResource ToResourceFromEntity(Fermentation entity)
    {
        return new FermentationResource(
                entity.Id,
                entity.BatchId,
                entity.StartDate, 
                entity.EndDate, 
                entity.AverageTemperature,
                entity.InitialDensity, 
                entity.InitialPh, 
                entity.FinalDensity, 
                entity.FinalPh, 
                entity.ResidualSugar);
    }
    
}