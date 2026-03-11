using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.DomainDTO
{
    public sealed record DomainLogEntry
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("domain")]
        public string Domain { get; init; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; init; } = string.Empty;

        [JsonPropertyName("source")]
        public string Source { get; init; } = string.Empty;

        [JsonPropertyName("version")]
        public int Version { get; init; }
    }
}