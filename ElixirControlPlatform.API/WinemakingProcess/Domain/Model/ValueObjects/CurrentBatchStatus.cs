namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

public enum CurrentBatchStatus
{
    Collected,
    Fermentation,
    Clarification,
    Pressing,
    Aging,
    Bottling,
    Finished
}