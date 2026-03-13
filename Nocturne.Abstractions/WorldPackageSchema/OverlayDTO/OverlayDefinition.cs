using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.OverlayDTO
{
    public sealed record OverlayDefinitionDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = string.Empty;

        [JsonPropertyName("slug")]
        public string Slug { get; init; } = string.Empty;
        
        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; init; } = string.Empty;

        [JsonPropertyName("toneShift")]
        public string ToneShift { get; init; } = string.Empty;

        [JsonPropertyName("densityShift")]
        public string DensityShift { get; init; } = string.Empty;

        [JsonPropertyName("styleShift")]
        public string StyleShift { get; init; } = string.Empty;

        [JsonPropertyName("worldTypeShift")]
        public string WorldTypeShift { get; init; } = string.Empty;

        [JsonPropertyName("riskShift")]
        public string RiskShift { get; init; } = string.Empty;

        [JsonPropertyName("activationTags")]
        public List<string> ActivationTags { get; init; } = new();

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}