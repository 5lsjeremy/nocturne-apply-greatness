using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.OverlayDTO
{
    public sealed record OverlayStackDTO
    {
        [JsonPropertyName("activeOverlays")]
        public List<OverlayDefinitionDTO> ActiveOverlays { get; init; } = new();

        [JsonPropertyName("tags")]
        public OverlayTagsDTO Tags { get; init; } 
            = new OverlayTagsDTO("", "", "", "", "");

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}