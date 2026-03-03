using Nocturne.Abstractions.Overlays;

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

        bool IsFeasible { get; }
        string? FailureReason { get; }
    }
}