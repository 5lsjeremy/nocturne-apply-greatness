using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class ConceptEvaluation : IConceptEvaluation
    {
        public bool? IsClear { get; set; }
        public IReadOnlyList<string> ClarityRecommendations { get; set; } = Array.Empty<string>();
        public IReadOnlyList<string> ClarityQuestions { get; set; } = Array.Empty<string>();

        public IReadOnlyList<string> PitchRecommendations { get; set; } = Array.Empty<string>();
        public IReadOnlyList<string> TagRecommendations { get; set; } = Array.Empty<string>();

        public string? Good { get; set; }
        public string? Bad { get; set; }
        public string? Ugly { get; set; }

        public int? Momentum { get; set; }
        public int? Inertia { get; set; }
        public int? ClarityScore { get; set; }
        public int? SpecificityScore { get; set; }
        public int? NoveltyScore { get; set; }
        public int? CoherenceScore { get; set; }

        public IReadOnlyList<string> Risks { get; set; } = Array.Empty<string>();
        public IReadOnlyList<string> Recommendations { get; set; } = Array.Empty<string>();
        public IReadOnlyList<string> Questions { get; set; } = Array.Empty<string>();

        public string? TrajectoryParagraph { get; set; }

        public bool IsFeasible { get; set; }
        public string? FailureReason { get; set; }

        public bool BlockersResolved { get; set; }
    }
}