//v.01 updated 26.03.18

using Nocturne.Abstractions.Overlays;

namespace Nocturne.Surface.Overlays.Base;

public abstract class OverlayBase : IOverlay
{
    public IOverlayTags Tags { get; }

    public IReadOnlyList<string> SemanticTags { get; }
    public IReadOnlyList<string> EmotionalTags { get; }
    public IReadOnlyList<string> StructuralTags { get; }
    public IReadOnlyList<string> DomainTags { get; }

    protected OverlayBase(
        IOverlayTags tags,
        IReadOnlyList<string>? semanticTags,
        IReadOnlyList<string>? emotionalTags,
        IReadOnlyList<string>? structuralTags,
        IReadOnlyList<string>? domainTags)
    {
        Tags = tags ?? throw new ArgumentNullException(nameof(tags));

        // Defensive normalization: never allow null lists
        SemanticTags = semanticTags ?? Array.Empty<string>();
        EmotionalTags = emotionalTags ?? Array.Empty<string>();
        StructuralTags = structuralTags ?? Array.Empty<string>();
        DomainTags = domainTags ?? Array.Empty<string>();
    }
}