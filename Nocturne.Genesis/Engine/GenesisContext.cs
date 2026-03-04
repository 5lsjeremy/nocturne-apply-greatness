using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;

namespace Nocturne.Genesis.Engine
{
    public sealed class GenesisContext : IGenesisContext
    {
        public ISurfaceArtifact Seed { get; }

        public IDictionary<string, object?> Answers { get; }
            = new Dictionary<string, object?>();

        public IList<ICard> Cards { get; }
            = new List<ICard>();

        public IOverlayTags? OverlayTags { get; }

        // NEW — concept is now required and immutable
        public IConcept Concept { get; }

        public GenesisContext(
            ISurfaceArtifact seed,
            IConcept concept,
            IOverlayTags? tags = null)
        {
            Seed = seed;
            Concept = concept;
            OverlayTags = tags;
        }
    }
}