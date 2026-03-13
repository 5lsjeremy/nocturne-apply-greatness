using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.CardDTO
{
    public sealed record CardDefinition
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = string.Empty;

        [JsonPropertyName("slug")]
        public string Slug { get; init; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; init; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; init; } = string.Empty;

        [JsonPropertyName("mechanics")]
        public List<string> Mechanics { get; init; } = new();

        [JsonPropertyName("narrative")]
        public string Narrative { get; init; } = string.Empty;

        [JsonPropertyName("tags")]
        public List<string> Tags { get; init; } = new();

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}