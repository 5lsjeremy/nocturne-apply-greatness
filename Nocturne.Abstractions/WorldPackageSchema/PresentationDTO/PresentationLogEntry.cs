using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.PresentationDTO
{
    public sealed record PresentationLogEntry
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("presentationId")]
        public string PresentationId { get; init; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; init; } = string.Empty;

        [JsonPropertyName("category")]
        public string Category { get; init; } = string.Empty;

        [JsonPropertyName("source")]
        public string Source { get; init; } = string.Empty;

        [JsonPropertyName("version")]
        public int Version { get; init; }
    }
}