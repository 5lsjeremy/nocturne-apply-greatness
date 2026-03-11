using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.CardDTO
{
    public sealed record CardLogs
    {
        [JsonPropertyName("entries")]
        public List<CardLogEntry> Entries { get; init; } = new();
    }
}