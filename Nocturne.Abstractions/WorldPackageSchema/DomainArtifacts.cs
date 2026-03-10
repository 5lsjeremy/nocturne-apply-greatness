using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema
{
    public  class DomainArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "domains/";

        [JsonPropertyName("items")]
        public Dictionary<string, ArtifactEntry> Items { get; init; } = new();

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("domains/logs.json");
    }
}