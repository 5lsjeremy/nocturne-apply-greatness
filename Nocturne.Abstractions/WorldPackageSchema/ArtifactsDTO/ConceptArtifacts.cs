using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO
{
    public class ConceptArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "concept/";

        [JsonPropertyName("concept")]
        public ArtifactEntry Concept { get; init; } = new("concept/concept.json");

        [JsonPropertyName("clarity")]
        public ArtifactEntry Clarity { get; init; } = new("concept/clarity.json");

        [JsonPropertyName("pitch")]
        public ArtifactEntry Pitch { get; init; } = new("concept/pitch.json");

        [JsonPropertyName("tags")]
        public ArtifactEntry Tags { get; init; } = new("concept/tags.json");

        [JsonPropertyName("feasibility")]
        public ArtifactEntry Feasibility { get; init; } = new("concept/feasibility.json");

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("concept/logs.json");
    }
}