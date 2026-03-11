using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO
{
    public sealed record StarterDeckMetadata
    {
        [JsonPropertyName("author")]
        public string Author { get; init; } = "system";

        [JsonPropertyName("origin")]
        public string Origin { get; init; } = "inference";

        [JsonPropertyName("fingerprint")]
        public string Fingerprint { get; init; } = string.Empty;

        [JsonPropertyName("version")]
        public int Version { get; init; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}