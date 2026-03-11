using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO;

public  class WorldPackage
{
    [JsonPropertyName("worldName")]
    public string WorldName { get; init; } = string.Empty;

    [JsonPropertyName("version")]
    public string Version { get; init; } = "1.0";

    [JsonPropertyName("seedId")]
    public string SeedId { get; init; } = string.Empty;

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonPropertyName("lifecycle")]
    public string Lifecycle { get; init; } = "cache";

    [JsonPropertyName("artifacts")]
    public ArtifactsRegistry Artifacts { get; init; } = new();
}