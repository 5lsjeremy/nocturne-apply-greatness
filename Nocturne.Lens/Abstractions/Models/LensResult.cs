using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Lens.Enums;

namespace Nocturne.Lens.Abstractions.Models
{
    public sealed class LensResult : ILensResult
    {
        public IReadOnlyList<ILensDiagnosis> Diagnoses { get; init; }
            = Array.Empty<ILensDiagnosis>();

        public IReadOnlyList<ILensQuestion> Questions { get; init; }
            = Array.Empty<ILensQuestion>();

        public IReadOnlyList<ILensPlannedUpdate> PlannedUpdates { get; init; }
            = Array.Empty<ILensPlannedUpdate>();
    }
    
    public sealed class LensDiagnosis : ILensDiagnosis
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public string TargetId { get; init; } = string.Empty;
        public string Message { get; init; } = string.Empty;
        public LensIssueSeverity Severity { get; init; }
        public LensPassType SourcePass { get; init; }
    }
    
    public sealed class LensQuestion : ILensQuestion
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public string Prompt { get; init; } = string.Empty;

        public IReadOnlyList<ILensChoice> Choices { get; init; }
            = Array.Empty<ILensChoice>();
    }
    
    public sealed class LensChoice : ILensChoice
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public string Label { get; init; } = string.Empty;
        public string? Details { get; init; }
    }
    
    public sealed class LensPlannedUpdate : ILensPlannedUpdate
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public string TargetId { get; init; } = string.Empty;
        public LensMutationType MutationType { get; init; }
        public string Payload { get; init; } = string.Empty;
    }

}