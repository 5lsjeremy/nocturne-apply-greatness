using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record ClaritySection
    {
        [JsonPropertyName("strengths")]
        public List<string> Strengths { get; init; } = new();

        [JsonPropertyName("opportunities")]
        public List<string> Opportunities { get; init; } = new();

        [JsonPropertyName("weaknesses")]
        public List<string> Weaknesses { get; init; } = new();

        [JsonPropertyName("ambiguities")]
        public List<string> Ambiguities { get; init; } = new();

        [JsonPropertyName("risks")]
        public List<string> Risks { get; init; } = new();

        [JsonPropertyName("driftHazards")]
        public List<string> DriftHazards { get; init; } = new();

        [JsonPropertyName("contradictions")]
        public List<string> Contradictions { get; init; } = new();
    }
}