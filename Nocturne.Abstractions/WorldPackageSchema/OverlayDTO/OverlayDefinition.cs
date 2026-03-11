using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.OverlayDTO
{
    public sealed class OverlayDefinition
    {
        [JsonPropertyName("overlayName")]
        public string OverlayName { get; init; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; init; } = string.Empty;

        [JsonPropertyName("tags")]
        public List<string> Tags { get; init; } = new();

        [JsonPropertyName("rules")]
        public List<string> Rules { get; init; } = new();

        [JsonPropertyName("appliesTo")]
        public List<string> AppliesTo { get; init; } = new();

        [JsonPropertyName("risks")]
        public List<string> Risks { get; init; } = new();

        [JsonPropertyName("opportunities")]
        public List<string> Opportunities { get; init; } = new();

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}