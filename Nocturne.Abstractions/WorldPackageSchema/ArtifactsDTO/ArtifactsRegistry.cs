using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO
{
    public class ArtifactsRegistry
    {
        [JsonPropertyName("concept")]
        public ConceptArtifacts Concept { get; init; } = new();

        [JsonPropertyName("overlays")]
        public OverlayArtifacts Overlays { get; init; } = new();

        [JsonPropertyName("domains")]
        public DomainArtifacts Domains { get; init; } = new();

        [JsonPropertyName("cards")]
        public CardArtifacts Cards { get; init; } = new();

        [JsonPropertyName("starterDeck")]
        public StarterDeckArtifacts StarterDeck { get; init; } = new();

        [JsonPropertyName("presentation")]
        public PresentationArtifacts Presentation { get; init; } = new();

        [JsonPropertyName("surfaceLogs")]
        public ArtifactEntry SurfaceLogs { get; init; } = new("surface/logs.json");
    }
}