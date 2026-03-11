using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO
{
    public sealed record LlmStarterDeckResponse
    {
        [JsonPropertyName("title")]
        public string Title { get; init; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; init; } = string.Empty;

        [JsonPropertyName("cardIds")]
        public List<string> CardIds { get; init; } = new();

        [JsonPropertyName("tags")]
        public List<string> Tags { get; init; } = new();
    }
}