using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.DomainDTO
{
    public sealed record DomainFeasibility
    {
        [JsonPropertyName("creativePotential")]
        public string CreativePotential { get; init; } = string.Empty;

        [JsonPropertyName("productionRisks")]
        public List<string> ProductionRisks { get; init; } = new();

        [JsonPropertyName("opportunities")]
        public List<string> Opportunities { get; init; } = new();

        [JsonPropertyName("pitfalls")]
        public List<string> Pitfalls { get; init; } = new();

        [JsonPropertyName("alignmentWithWorld")]
        public string AlignmentWithWorld { get; init; } = string.Empty;

        [JsonPropertyName("expectedComplexity")]
        public string ExpectedComplexity { get; init; } = string.Empty;

        [JsonPropertyName("recommendedFocusAreas")]
        public List<string> RecommendedFocusAreas { get; init; } = new();

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}