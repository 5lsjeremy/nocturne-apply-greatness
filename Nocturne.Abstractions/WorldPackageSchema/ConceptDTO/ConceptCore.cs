using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record ConceptCore
    {
        [JsonPropertyName("worldName")]
        public string WorldName { get; init; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; init; } = string.Empty;

        [JsonPropertyName("themes")]
        public List<string> Themes { get; init; } = new();

        [JsonPropertyName("coreFantasy")]
        public string CoreFantasy { get; init; } = string.Empty;

        [JsonPropertyName("tone")]
        public string Tone { get; init; } = string.Empty;

        [JsonPropertyName("genre")]
        public string Genre { get; init; } = string.Empty;

        [JsonPropertyName("setting")]
        public string Setting { get; init; } = string.Empty;

        [JsonPropertyName("playerFantasy")]
        public string PlayerFantasy { get; init; } = string.Empty;

        [JsonPropertyName("creativeNorthStar")]
        public string CreativeNorthStar { get; init; } = string.Empty;

        [JsonPropertyName("seedId")]
        public string SeedId { get; init; } = string.Empty;

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}