using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.SurfaceDTO
{
    public sealed class SurfaceLogEntry
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; } = string.Empty;

        [JsonPropertyName("source")]
        public string Source { get; init; } = string.Empty;

        [JsonPropertyName("version")]
        public int Version { get; init; }
    }
}