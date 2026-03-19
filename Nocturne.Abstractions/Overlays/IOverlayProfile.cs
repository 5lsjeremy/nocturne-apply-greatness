//v.01 updated 26.03.18

namespace Nocturne.Abstractions.Overlays
{
    public interface IOverlayProfile
    {
        IOverlayTags Tags { get; }
        IReadOnlyList<string> SemanticTags { get; }
        IReadOnlyList<string> EmotionalTags { get; }
        IReadOnlyList<string> StructuralTags { get; }
        IReadOnlyList<string> DomainTags { get; }
    }
}