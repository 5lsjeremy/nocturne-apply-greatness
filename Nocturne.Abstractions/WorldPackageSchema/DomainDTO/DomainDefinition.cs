using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.DomainDTO
{
    public sealed class DomainDefinition
    {
        [JsonPropertyName("domainName")]
        public string DomainName { get; init; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; init; } = string.Empty;

        [JsonPropertyName("boundaries")]
        public List<string> Boundaries { get; init; } = new();

        [JsonPropertyName("tone")]
        public string Tone { get; init; } = string.Empty;

        [JsonPropertyName("tags")]
        public List<string> Tags { get; init; } = new();

        [JsonPropertyName("opportunities")]
        public List<string> Opportunities { get; init; } = new();

        [JsonPropertyName("risks")]
        public List<string> Risks { get; init; } = new();

        [JsonPropertyName("driftWarnings")]
        public List<string> DriftWarnings { get; init; } = new();

        [JsonPropertyName("pressureTestSeeds")]
        public List<string> PressureTestSeeds { get; init; } = new();

        [JsonPropertyName("prismSeeds")]
        public List<string> PrismSeeds { get; init; } = new();

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}