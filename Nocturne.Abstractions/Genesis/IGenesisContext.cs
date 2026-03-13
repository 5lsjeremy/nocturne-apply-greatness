using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisContext
    {
        ISurfaceArtifact Seed { get; }

        IDictionary<string, object?> Answers { get; }

        IList<ICard> Cards { get; }

        IOverlayTags? OverlayTags { get; }

        IConcept Concept { get; }

        ISurfaceLogger Logger { get; }

        // Unified world‑package prompt (replaces all legacy prompts)
        string BuildUnifiedWorldPackagePrompt(IOverlayTags? tags = null);
    }
}