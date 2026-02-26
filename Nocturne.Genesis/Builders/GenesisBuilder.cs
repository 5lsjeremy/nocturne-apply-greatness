using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Builders
{
    internal sealed class GenesisBuilder : IGenesisBuilder
    {
        public IStarterDeck BuildStarterDeck(
            ISurfaceArtifact seed,
            IGenesisContext context,
            IGenesisInferenceResult inference)
        {
            // MVP: inference already contains the starter deck
            return inference.StarterDeck;
        }
    }
}