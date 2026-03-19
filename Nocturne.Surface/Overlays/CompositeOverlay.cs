//v.01 updated 26.03.18

using Nocturne.Abstractions.Overlays;

namespace Nocturne.Surface.Overlays
{
    public sealed class CompositeOverlay : ICompositeOverlay
    {
        public IOverlay Base { get; }
        public IOverlay Inferred { get; }
        public IOverlay? Custom { get; }

        public CompositeOverlay(IOverlay baseOverlay, IOverlay inferredOverlay, IOverlay? customOverlay = null)
        {
            Base = baseOverlay;
            Inferred = inferredOverlay;
            Custom = customOverlay;

            // Merge tags in priority order: custom → inferred → base
            Tags = Custom?.Tags ?? Inferred.Tags ?? Base.Tags;

            SemanticTags = Merge(o => o.SemanticTags);
            EmotionalTags = Merge(o => o.EmotionalTags);
            StructuralTags = Merge(o => o.StructuralTags);
            DomainTags = Merge(o => o.DomainTags);
        }

        public IOverlayTags Tags { get; }

        public IReadOnlyList<string> SemanticTags { get; }
        public IReadOnlyList<string> EmotionalTags { get; }
        public IReadOnlyList<string> StructuralTags { get; }
        public IReadOnlyList<string> DomainTags { get; }

        private IReadOnlyList<string> Merge(Func<IOverlay, IReadOnlyList<string>> selector)
        {
            // Priority: custom → inferred → base
            if (Custom != null && selector(Custom).Count > 0)
                return selector(Custom);

            if (selector(Inferred).Count > 0)
                return selector(Inferred);

            return selector(Base);
        }
    }
}