using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record ConceptArtifactsDTO(
        [property: JsonPropertyName("id")]   string Id,
        [property: JsonPropertyName("slug")] string Slug,
        [property: JsonPropertyName("core")] ConceptCore Core,
        [property: JsonPropertyName("clarity")] ConceptClarity Clarity,
        [property: JsonPropertyName("pitch")] ConceptPitch Pitch,
        [property: JsonPropertyName("tags")] ConceptTags Tags,
        [property: JsonPropertyName("feasibility")] ConceptFeasibility Feasibility,
        [property: JsonPropertyName("logs")] ConceptLogs Logs
    );
}