using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirControlPlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class ClarificationResourceFromEntityAssembler
{
     public static ClarificationResource ToResourceFromEntity(Clarification entity)
     {
         return new ClarificationResource(  
             entity.Id,
             entity.BatchId, 
             entity.ProductsUsed, 
             entity.ClarificationMethod,
             entity.FiltrationDate, 
             entity.ClarityLevel, 
             entity.StartDate,
             entity.EndDate);
     }
}