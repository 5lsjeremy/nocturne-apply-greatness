using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.PresentationDTO
{
    public sealed class PresentationLogs
    {
        [JsonPropertyName("entries")]
        public List<PresentationLogEntry> Entries { get; init; } = new();
    }
}