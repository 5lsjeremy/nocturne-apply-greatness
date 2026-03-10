using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema
{
    public  class OverlayArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "overlays/";

        [JsonPropertyName("genesis")]
        public ArtifactEntry GenesisOverlay { get; init; } = new("overlays/genesis/overlay.json");

        [JsonPropertyName("lens")]
        public ArtifactEntry LensOverlay { get; init; } = new("overlays/lens/overlay.json");

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("overlays/logs.json");
    }
}