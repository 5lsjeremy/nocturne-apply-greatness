using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IConcept
    {
        string WorldConcept { get; }

        bool? IsClear { get; }
        IReadOnlyList<string> ClarityRecommendations { get; }
        IReadOnlyList<string> ClarityQuestions { get; }

        string? Pitch { get; }
        IReadOnlyList<string> PitchRecommendations { get; }

        IOverlayTags? Tags { get; }
        IReadOnlyList<string> TagRecommendations { get; }
        
        IReadOnlyCollection<ISurfaceLogEntry> Logs { get; }
        
        bool IsFeasible { get; }
        string? FailureReason { get; }
    }
}