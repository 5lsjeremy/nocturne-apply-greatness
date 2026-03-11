using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.OverlayDTO
{
    public sealed class OverlayLogs
    {
        [JsonPropertyName("entries")]
        public List<OverlayLogEntry> Entries { get; init; } = new();
    }
}