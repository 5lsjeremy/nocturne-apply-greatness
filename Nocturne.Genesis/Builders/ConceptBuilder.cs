using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;
using Nocturne.Genesis.Concepts;

namespace Nocturne.Genesis.Builders
{
    internal sealed class ConceptBuilder : IConceptBuilder
    {
        public string WorldConcept { get; }

        public bool? IsClear { get; private set; }
        public IReadOnlyList<string> ClarityRecommendations { get; private set; } = Array.Empty<string>();
        public IReadOnlyList<string> ClarityQuestions { get; private set; } = Array.Empty<string>();

        public string? Pitch { get; private set; }
        public IReadOnlyList<string> PitchRecommendations { get; private set; } = Array.Empty<string>();

        public IOverlayTags? Tags { get; private set; }
        public IReadOnlyList<string> TagRecommendations { get; private set; } = Array.Empty<string>();

        public bool IsFeasible { get; private set; }
        public string? FailureReason { get; private set; }

        public ConceptBuilder(string worldConcept)
        {
            WorldConcept = worldConcept;
        }

        public void SetClarity(bool isClear, IReadOnlyList<string> recs, IReadOnlyList<string> questions)
        {
            IsClear = isClear;
            ClarityRecommendations = recs;
            ClarityQuestions = questions;
        }

        public void SetPitch(string? pitch, IReadOnlyList<string> recs)
        {
            Pitch = pitch;
            PitchRecommendations = recs;
        }

        public void SetTags(IOverlayTags? tags, IReadOnlyList<string> recs)
        {
            Tags = tags;
            TagRecommendations = recs;
        }

        public void MarkFailure(string reason)
        {
            IsFeasible = false;
            FailureReason = reason;
        }

        public void MarkSuccess()
        {
            IsFeasible = true;
            FailureReason = null;
        }

        public IConcept Build()
        {
            return new Concept(
                WorldConcept,
                IsClear,
                ClarityRecommendations,
                ClarityQuestions,
                Pitch,
                PitchRecommendations,
                Tags,
                TagRecommendations,
                IsFeasible,
                FailureReason
            );
        }
    }
}