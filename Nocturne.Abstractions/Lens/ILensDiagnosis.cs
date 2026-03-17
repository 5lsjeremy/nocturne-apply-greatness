using Nocturne.Abstractions.Lens.Enums;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensDiagnosis
    {
        string Id { get; }
        string TargetId { get; }
        string Message { get; }
        LensIssueSeverity Severity { get; }
        LensPassType SourcePass { get; }
    }
}