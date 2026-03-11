using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO
{
    public class PresentationArtifacts
    {
        [JsonPropertyName("root")]
        public string Root { get; init; } = "presentation/";

        [JsonPropertyName("logs")]
        public ArtifactEntry Logs { get; init; } = new("presentation/logs.json");
    }
}