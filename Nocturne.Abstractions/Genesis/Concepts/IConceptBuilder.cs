using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IConceptBuilder
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

        void SetClarity(bool isClear, IReadOnlyList<string> recommendations, IReadOnlyList<string> questions);
        void SetPitch(string? pitch, IReadOnlyList<string> recommendations);
        void SetTags(IOverlayTags? tags, IReadOnlyList<string> recommendations);

        void MarkFailure(string reason);
        void MarkSuccess();

        IConcept Build();
    }
}