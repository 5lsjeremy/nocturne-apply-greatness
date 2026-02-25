using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Artifacts
{
    internal sealed class StarterDeckArtifact
    {
        public string Name { get; set; } = string.Empty;

        public List<ICard> Cards { get; set; } = new();

        public Dictionary<string, object> Metadata { get; set; } = new();
    }
}