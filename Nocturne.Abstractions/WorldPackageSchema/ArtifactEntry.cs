using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema
{
    public class ArtifactEntry
    {
        public ArtifactEntry(string path)
        {
            Path = path;
        }

        [JsonPropertyName("path")]
        public string Path { get; init; }

        [JsonPropertyName("exists")]
        public bool Exists { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; } = 1;

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("hash")]
        public string? Hash { get; set; }
    }
}