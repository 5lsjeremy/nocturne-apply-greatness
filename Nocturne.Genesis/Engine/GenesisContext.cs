using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Overlays;

namespace Nocturne.Genesis.Engine;

public sealed class GenesisContext : IGenesisContext
{
    public ISurfaceArtifact Seed { get; }
    public IDictionary<string, object?> Answers { get; } = new Dictionary<string, object?>();
    public IList<ICard> Cards { get; }
    public IOverlayTags? OverlayTags { get; set; }   // NEW

    public GenesisContext(ISurfaceArtifact seed, IOverlayTags? tags = null)
    {
        Seed = seed;
        OverlayTags = tags;
    }
}