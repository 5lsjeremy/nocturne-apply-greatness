using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record ConceptDefinition
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = string.Empty;

        [JsonPropertyName("slug")]
        public string Slug { get; init; } = string.Empty;

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

        // Optional but already part of your schema family
        [JsonPropertyName("logs")]
        public ConceptLogs Logs { get; init; } = new();
    }
}