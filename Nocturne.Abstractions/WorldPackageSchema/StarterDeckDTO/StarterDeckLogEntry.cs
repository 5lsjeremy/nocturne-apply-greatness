using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO
{
    public sealed record StarterDeckLogEntry
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("deckId")]
        public string DeckId { get; init; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; init; } = string.Empty;

        [JsonPropertyName("category")]
        public string Category { get; init; } = string.Empty;

        [JsonPropertyName("source")]
        public string Source { get; init; } = string.Empty;

        [JsonPropertyName("version")]
        public int Version { get; init; }
    }
}