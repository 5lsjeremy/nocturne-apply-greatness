using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.CardDTO
{
    public sealed class CardDefinition
    {
        [JsonPropertyName("cardId")]
        public string CardId { get; init; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; init; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; init; } = string.Empty;

        [JsonPropertyName("category")]
        public string Category { get; init; } = string.Empty;

        [JsonPropertyName("tags")]
        public List<string> Tags { get; init; } = new();

        [JsonPropertyName("effects")]
        public List<string> Effects { get; init; } = new();

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}