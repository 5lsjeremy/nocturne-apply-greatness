using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.OverlayDTO
{
    public sealed class OverlayLogEntry
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("overlay")]
        public string Overlay { get; init; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; init; } = string.Empty;

        [JsonPropertyName("source")]
        public string Source { get; init; } = string.Empty;

        [JsonPropertyName("version")]
        public int Version { get; init; }
    }
}