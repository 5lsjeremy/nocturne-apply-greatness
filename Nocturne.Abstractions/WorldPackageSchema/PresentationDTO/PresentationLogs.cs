using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.PresentationDTO
{
    public sealed record PresentationLogs
    {
        [JsonPropertyName("entries")]
        public List<PresentationLogEntry> Entries { get; init; } = new();
    }
}