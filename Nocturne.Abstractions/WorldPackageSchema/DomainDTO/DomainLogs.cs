using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.DomainDTO
{
    public sealed class DomainLogs
    {
        [JsonPropertyName("entries")]
        public List<DomainLogEntry> Entries { get; init; } = new();
    }
}