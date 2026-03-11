using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.PresentationDTO
{
    public sealed record LlmPresentationResponse
    {
        [JsonPropertyName("title")]
        public string Title { get; init; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; init; } = string.Empty;

        [JsonPropertyName("layout")]
        public string Layout { get; init; } = "default";

        [JsonPropertyName("style")]
        public string Style { get; init; } = "standard";

        [JsonPropertyName("tags")]
        public List<string> Tags { get; init; } = new();
    }
}