//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Lens.Enums;

namespace Nocturne.Lens.Abstractions.Models
{
    public sealed class LensDiagnosis : ILensDiagnosis
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public string TargetId { get; init; } = string.Empty;
        public string Message { get; init; } = string.Empty;
        public LensIssueSeverity Severity { get; init; }
        public LensPassType SourcePass { get; init; }
    }
}