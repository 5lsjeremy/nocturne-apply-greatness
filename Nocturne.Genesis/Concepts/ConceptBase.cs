using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;

namespace Nocturne.Genesis.Concepts
{
    internal abstract class ConceptBase : IConcept
    {
        public string WorldConcept { get; }

        public bool? IsClear { get; protected set; }
        public IReadOnlyList<string> ClarityRecommendations { get; protected set; } = Array.Empty<string>();
        public IReadOnlyList<string> ClarityQuestions { get; protected set; } = Array.Empty<string>();

        public string? Pitch { get; protected set; }
        public IReadOnlyList<string> PitchRecommendations { get; protected set; } = Array.Empty<string>();

        public IOverlayTags? Tags { get; protected set; }
        public IReadOnlyList<string> TagRecommendations { get; protected set; } = Array.Empty<string>();

        public bool IsFeasible { get; protected set; }
        public string? FailureReason { get; protected set; }

        protected ConceptBase(string worldConcept)
        {
            WorldConcept = worldConcept;
        }

        protected void MarkFailure(string reason)
        {
            IsFeasible = false;
            FailureReason = reason;
        }

        protected void MarkSuccess()
        {
            IsFeasible = true;
            FailureReason = null;
        }
    }
}