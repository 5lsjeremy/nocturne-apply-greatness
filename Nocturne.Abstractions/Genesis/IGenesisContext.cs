using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis;

public interface IGenesisContext
{
    ISurfaceArtifact Seed { get; }

    IDictionary<string, object?> Answers { get; }

    IList<ICard> Cards { get; }

    IOverlayTags? OverlayTags { get; }

    IConcept Concept { get; }

    // NEW — prompt builders for world‑package inference
    string BuildDomainPrompt(IOverlayTags? tags = null);
    string BuildConceptPrompt(IOverlayTags? tags = null);
    string BuildCardPrompt(IOverlayTags? tags = null);
    string BuildStarterDeckPrompt(IOverlayTags? tags = null);
    string BuildPresentationPrompt(IOverlayTags? tags = null);
}