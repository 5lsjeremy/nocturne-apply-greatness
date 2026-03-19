//v.01 updated 26.03.18
using Nocturne.Abstractions.Overlays;

namespace Nocturne.Surface.Overlays
{
    public sealed class GenesisOverlay : IGenesisOverlay
    {
        public IOverlayTags Tags { get; }
        public IReadOnlyList<string> SemanticTags { get; }
        public IReadOnlyList<string> EmotionalTags { get; }
        public IReadOnlyList<string> StructuralTags { get; }
        public IReadOnlyList<string> DomainTags { get; }

        public GenesisOverlay(
            IOverlayTags tags,
            IReadOnlyList<string> semanticTags,
            IReadOnlyList<string> emotionalTags,
            IReadOnlyList<string> structuralTags,
            IReadOnlyList<string> domainTags)
        {
            Tags = tags;
            SemanticTags = semanticTags;
            EmotionalTags = emotionalTags;
            StructuralTags = structuralTags;
            DomainTags = domainTags;
        }
    }
}