using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Artifacts
{
    internal sealed class GenesisArtifact : IArtifact
    {
        public string Id { get; set; } = string.Empty;

        public StarterDeckArtifact StarterDeck { get; set; } = new StarterDeckArtifact();
    }
}