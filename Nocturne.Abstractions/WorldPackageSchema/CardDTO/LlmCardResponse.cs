using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.CardDTO
{
    public sealed record LlmCardResponse
    {
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
    }
}