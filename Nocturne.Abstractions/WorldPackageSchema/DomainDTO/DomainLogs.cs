using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.DomainDTO
{
    public sealed record DomainLogs
    {
        [JsonPropertyName("entries")]
        public List<DomainLogEntry> Entries { get; init; } = new();
    }
}