using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.CardDTO
{
    public sealed class CardLogs
    {
        [JsonPropertyName("entries")]
        public List<CardLogEntry> Entries { get; init; } = new();
    }
}