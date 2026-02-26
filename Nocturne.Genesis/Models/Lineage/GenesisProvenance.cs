using Nocturne.Abstractions.Genesis.Lineage;

namespace Nocturne.Genesis.Models.Lineage
{
    public class GenesisProvenance : IProvenance
    {
        public string SeedId { get; init; }
        public IReadOnlyDictionary<string, string> PromptAnswers { get; init; }
        public IReadOnlyList<string> LlmContributions { get; init; }
        public IReadOnlyList<string> BuilderContributions { get; init; }
        public IReadOnlyList<string> InferenceRulesApplied { get; init; }
        public DateTime Timestamp { get; init; }
    }
}