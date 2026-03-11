using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.CardDTO
{
    public sealed class CardLogEntry
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("cardId")]
        public string CardId { get; init; } = string.Empty;

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