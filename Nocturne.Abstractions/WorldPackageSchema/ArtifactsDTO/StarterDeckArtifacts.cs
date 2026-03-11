using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO
{
    public  class StarterDeckArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "starter_deck/";

        [JsonPropertyName("deck")]
        public ArtifactEntry Deck { get; init; } = new("starter_deck/deck.json");

        [JsonPropertyName("cards")]
        public Dictionary<string, ArtifactEntry> Cards { get; init; } = new();

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("starter_deck/logs.json");
    }
}