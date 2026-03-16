using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.PresentationDTO
{
    public sealed record PresentationDefinition
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = string.Empty;

        [JsonPropertyName("slug")]
        public string Slug { get; init; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; init; } = string.Empty;

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; init; } = string.Empty;

        [JsonPropertyName("overview")]
        public string Overview { get; init; } = string.Empty;

        [JsonPropertyName("pillars")]
        public List<string> Pillars { get; init; } = new();

        [JsonPropertyName("recommendedNextSteps")]
        public List<string> RecommendedNextSteps { get; init; } = new();

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}