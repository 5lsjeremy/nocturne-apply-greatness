using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO
{
    public sealed class StarterDeckArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "starter-deck/";

        [JsonPropertyName("definition")]
        public ArtifactEntry Definition { get; init; } = new("starter-deck/definition.json");

        // Domains included in the starter deck
        [JsonPropertyName("domains")]
        public ArtifactEntry Domains { get; init; } = new("starter-deck/domains.json");

        // Cards included in the starter deck
        [JsonPropertyName("cards")]
        public ArtifactEntry Cards { get; init; } = new("starter-deck/cards.json");

        // Sparks are NOT part of the starter deck initially,
        // but Lens may add early sparks during refinement.
        [JsonPropertyName("sparks")]
        public ArtifactEntry Sparks { get; init; } = new("starter-deck/sparks.json");

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("starter-deck/logs.json");
    }
}