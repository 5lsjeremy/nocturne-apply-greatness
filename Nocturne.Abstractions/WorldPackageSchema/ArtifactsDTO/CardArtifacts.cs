using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO
{
    public sealed class CardArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "cards/";

        // Each card gets its own folder: cards/{slug}/card.json
        [JsonPropertyName("items")]
        public Dictionary<string, ArtifactEntry> Items { get; init; } = new();

        // NEW: Sparks associated with cards live in sparks/, but we expose a mapping here
        [JsonPropertyName("sparkIndex")]
        public ArtifactEntry SparkIndex { get; init; } = new("cards/spark-index.json");

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("cards/logs.json");
    }
}