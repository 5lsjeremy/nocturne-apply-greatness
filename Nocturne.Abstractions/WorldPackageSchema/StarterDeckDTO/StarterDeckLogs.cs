using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO
{
    public sealed record StarterDeckLogs
    {
        [JsonPropertyName("entries")]
        public List<StarterDeckLogEntry> Entries { get; init; } = new();
    }
}
