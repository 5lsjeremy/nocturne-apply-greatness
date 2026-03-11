using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed class ConceptPitch
    {
        [JsonPropertyName("tagline")]
        public string Tagline { get; init; } = string.Empty;

        [JsonPropertyName("oneSentencePitch")]
        public string OneSentencePitch { get; init; } = string.Empty;

        [JsonPropertyName("thirtySecondPitch")]
        public string ThirtySecondPitch { get; init; } = string.Empty;

        [JsonPropertyName("marketPosition")]
        public string MarketPosition { get; init; } = string.Empty;

        [JsonPropertyName("emotionalHook")]
        public string EmotionalHook { get; init; } = string.Empty;

        [JsonPropertyName("playerPromise")]
        public string PlayerPromise { get; init; } = string.Empty;

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}