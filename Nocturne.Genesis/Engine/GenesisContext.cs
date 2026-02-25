using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Engine
{
    internal sealed class GenesisContext : IGenesisContext
    {
        public ISurfaceArtifact Seed { get; }

        public IDictionary<string, object> Answers { get; } = new Dictionary<string, object>();

        public IList<ICard> Cards { get; } = new List<ICard>();

        public GenesisContext(ISurfaceArtifact seed)
        {
            Seed = seed;
        }
    }
}