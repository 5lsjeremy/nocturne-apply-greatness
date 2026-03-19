//v.01 updated 26.03.18
using Nocturne.Abstractions.Overlays;

namespace Nocturne.Surface.Overlays
{
    public sealed class LensOverlay : ILensOverlay
    {
        public IOverlayTags Tags { get; }
        public IReadOnlyList<string> SemanticTags { get; }
        public IReadOnlyList<string> EmotionalTags { get; }
        public IReadOnlyList<string> StructuralTags { get; }
        public IReadOnlyList<string> DomainTags { get; }

        // Lens‑specific semantic modifiers
        public IReadOnlyList<string> DriftSensitiveTags { get; }
        public IReadOnlyList<string> QuestionBiasTags { get; }
        public IReadOnlyList<string> UpdateHeuristicTags { get; }

        public LensOverlay(
            IOverlayTags tags,
            IReadOnlyList<string> semanticTags,
            IReadOnlyList<string> emotionalTags,
            IReadOnlyList<string> structuralTags,
            IReadOnlyList<string> domainTags,
            IReadOnlyList<string> driftSensitiveTags,
            IReadOnlyList<string> questionBiasTags,
            IReadOnlyList<string> updateHeuristicTags)
        {
            Tags = tags;
            SemanticTags = semanticTags;
            EmotionalTags = emotionalTags;
            StructuralTags = structuralTags;
            DomainTags = domainTags;

            DriftSensitiveTags = driftSensitiveTags;
            QuestionBiasTags = questionBiasTags;
            UpdateHeuristicTags = updateHeuristicTags;
        }
    }
}