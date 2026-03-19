namespace Nocturne.Abstractions.Lens
{
    public interface ILensVersionInfo
    {
        string LensCycleId { get; }
        string EngineVersion { get; }
        string RuleSetVersion { get; }
        string PassPipelineVersion { get; }
        DateTimeOffset Timestamp { get; }
    }
}