using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO
{
    public sealed class SparkArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "sparks/";

        [JsonPropertyName("items")]
        public Dictionary<string, ArtifactEntry> Items { get; init; } = new();

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("sparks/logs.json");
    }
}