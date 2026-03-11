using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record ConceptLogs
    {
        [JsonPropertyName("entries")]
        public List<ConceptLogEntry> Entries { get; init; } = new();
    }
}