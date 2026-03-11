using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed class ConceptClarity
    {
        [JsonPropertyName("clarityScore")]
        public int ClarityScore { get; init; }

        [JsonPropertyName("good")]
        public ClaritySection Good { get; init; } = new();

        [JsonPropertyName("bad")]
        public ClaritySection Bad { get; init; } = new();

        [JsonPropertyName("ugly")]
        public ClaritySection Ugly { get; init; } = new();

        [JsonPropertyName("notes")]
        public string Notes { get; init; } = string.Empty;

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}