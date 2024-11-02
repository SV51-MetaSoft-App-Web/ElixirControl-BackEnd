using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;

namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Queries;

public record GetFermentationByBatchIdQuery(int BatchId);