namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IConceptEvaluation
    {
        bool? IsClear { get; }
        IReadOnlyList<string> ClarityRecommendations { get; }
        IReadOnlyList<string> ClarityQuestions { get; }

        IReadOnlyList<string> PitchRecommendations { get; }
        IReadOnlyList<string> TagRecommendations { get; }

        string? Good { get; }
        string? Bad { get; }
        string? Ugly { get; }

        int? Momentum { get; }
        int? Inertia { get; }
        int? ClarityScore { get; }
        int? SpecificityScore { get; }
        int? NoveltyScore { get; }
        int? CoherenceScore { get; }

        IReadOnlyList<string> Risks { get; }
        IReadOnlyList<string> Recommendations { get; }
        IReadOnlyList<string> Questions { get; }

        string? TrajectoryParagraph { get; }

        bool IsFeasible { get; }
        string? FailureReason { get; }

        bool BlockersResolved { get; }
    }
}