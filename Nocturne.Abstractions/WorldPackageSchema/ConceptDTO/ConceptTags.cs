using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed class ConceptTags
    {
        [JsonPropertyName("conceptTags")]
        public List<string> ConceptTagsList { get; init; } = new();

        [JsonPropertyName("mechanicTags")]
        public List<string> MechanicTags { get; init; } = new();

        [JsonPropertyName("moodTags")]
        public List<string> MoodTags { get; init; } = new();

        [JsonPropertyName("themeTags")]
        public List<string> ThemeTags { get; init; } = new();

        [JsonPropertyName("settingTags")]
        public List<string> SettingTags { get; init; } = new();

        [JsonPropertyName("inferredDomains")]
        public List<string> InferredDomains { get; init; } = new();

        [JsonPropertyName("inferredSystems")]
        public List<string> InferredSystems { get; init; } = new();

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
    }
}