using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO
{
    public sealed record StarterDeckDefinition
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = string.Empty;

        [JsonPropertyName("slug")]
        public string Slug { get; init; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; init; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; init; } = string.Empty;

        [JsonPropertyName("cardIds")]
        public List<string> CardIds { get; init; } = new();

        [JsonPropertyName("tags")]
        public List<string> Tags { get; init; } = new();

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}