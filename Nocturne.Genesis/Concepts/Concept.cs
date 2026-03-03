using Nocturne.Abstractions.Overlays;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class Concept : ConceptBase
    {
        internal Concept(
            string worldConcept,
            bool? isClear,
            IReadOnlyList<string> clarityRecs,
            IReadOnlyList<string> clarityQuestions,
            string? pitch,
            IReadOnlyList<string> pitchRecs,
            IOverlayTags? tags,
            IReadOnlyList<string> tagRecs,
            bool isFeasible,
            string? failureReason)
            : base(worldConcept)
        {
            IsClear = isClear;
            ClarityRecommendations = clarityRecs;
            ClarityQuestions = clarityQuestions;

            Pitch = pitch;
            PitchRecommendations = pitchRecs;

            Tags = tags;
            TagRecommendations = tagRecs;

            IsFeasible = isFeasible;
            FailureReason = failureReason;
        }
    }
}