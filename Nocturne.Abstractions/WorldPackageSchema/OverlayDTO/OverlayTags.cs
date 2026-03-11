using System.Text.Json.Serialization;
using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.WorldPackageSchema.OverlayDTO
{
    public sealed record OverlayTagsDTO(
        [property: JsonPropertyName("tone")] string Tone,
        [property: JsonPropertyName("density")] string Density,
        [property: JsonPropertyName("style")] string Style,
        [property: JsonPropertyName("worldType")] string WorldType,
        [property: JsonPropertyName("risk")] string Risk
    ) : IOverlayTags;
}