using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record ConceptLogEntry
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; } = string.Empty;

        [JsonPropertyName("source")]
        public string Source { get; init; } = string.Empty;

        [JsonPropertyName("seedId")]
        public string SeedId { get; init; } = string.Empty;

        [JsonPropertyName("version")]
        public string Version { get; init; } = string.Empty;
    }
}