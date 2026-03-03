using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisContext
    {
        ISurfaceArtifact Seed { get; }

        IDictionary<string, object> Answers { get; }

        IList<ICard> Cards { get; }
        
        IOverlayTags? OverlayTags { get; }

        // You can extend later with tags/relationships if you formalize them as interfaces.
    }
}