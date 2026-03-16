using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record LlmConceptResponse
    {
        [JsonPropertyName("seedId")]
        public string SeedId { get; init; } = string.Empty;

        [JsonPropertyName("core")]
        public ConceptCore Core { get; init; } = new();

        [JsonPropertyName("clarity")]
        public ConceptClarity Clarity { get; init; } = new();

        [JsonPropertyName("pitch")]
        public ConceptPitch Pitch { get; init; } = new();

        [JsonPropertyName("tags")]
        public ConceptTags Tags { get; init; } = new();

        [JsonPropertyName("feasibility")]
        public ConceptFeasibility Feasibility { get; init; } = new();
    }
}