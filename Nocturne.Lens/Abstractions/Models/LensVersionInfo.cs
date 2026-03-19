//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;

namespace Nocturne.Lens.Abstractions.Models
{
    internal sealed class LensVersionInfo : ILensVersionInfo
    {
        public string LensCycleId { get; init; } = default!;
        public string EngineVersion { get; init; } = default!;
        public string RuleSetVersion { get; init; } = default!;
        public string PassPipelineVersion { get; init; } = default!;
        public DateTimeOffset Timestamp { get; init; }
    }
}