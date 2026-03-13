using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO
{
    public sealed class DomainArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "domains/";

        // Each domain gets its own folder: domains/{slug}/domain.json
        [JsonPropertyName("items")]
        public Dictionary<string, ArtifactEntry> Items { get; init; } = new();

        // NEW: Domain → Card mapping
        [JsonPropertyName("cardIndex")]
        public ArtifactEntry CardIndex { get; init; } = new("domains/card-index.json");

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("domains/logs.json");
    }
}