using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.SurfaceDTO
{
    public sealed class SurfaceLogs
    {
        [JsonPropertyName("entries")]
        public List<SurfaceLogEntry> Entries { get; init; } = new();
    }
}