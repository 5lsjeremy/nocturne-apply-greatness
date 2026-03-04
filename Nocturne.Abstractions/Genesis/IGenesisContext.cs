using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisContext
    {
        ISurfaceArtifact Seed { get; }

        IDictionary<string, object?> Answers { get; }

        IList<ICard> Cards { get; }

        IOverlayTags? OverlayTags { get; }

        // NEW — evaluated concept available to prompts + inference
        IConcept Concept { get; }
    }
}