using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO
{
    public sealed record WorldPackageIndexDto
    {
        [JsonPropertyName("packageId")]
        public string PackageId { get; init; } = string.Empty;

        [JsonPropertyName("worldName")]
        public string WorldName { get; init; } = string.Empty;

        [JsonPropertyName("version")]
        public string Version { get; init; } = "1.0";

        [JsonPropertyName("created")]
        public DateTime Created { get; init; }

        [JsonPropertyName("domains")]
        public List<string> Domains { get; init; } = new();

        [JsonPropertyName("cards")]
        public List<string> Cards { get; init; } = new();

        [JsonPropertyName("conceptId")]
        public string ConceptId { get; set; } = string.Empty;

        [JsonPropertyName("starterDeckId")]
        public string? StarterDeckId { get; set; } = null;

        [JsonPropertyName("presentationId")]
        public string PresentationId { get; set; } = string.Empty;
    }
}