using System.Text.Json;
using Nocturne.Genesis.Artifacts;

namespace Nocturne.Genesis.Modules
{
    internal static class GenesisArtifactSerializer
    {
        public static string Serialize(GenesisArtifact artifact)
            => JsonSerializer.Serialize(artifact);

        public static GenesisArtifact Deserialize(string json)
            => JsonSerializer.Deserialize<GenesisArtifact>(json);
    }
}