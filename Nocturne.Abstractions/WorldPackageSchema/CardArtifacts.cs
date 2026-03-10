using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema
{
    public sealed class CardArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "cards/";

        [JsonPropertyName("items")]
        public Dictionary<string, ArtifactEntry> Items { get; init; } = new();

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("cards/logs.json");
    }
}