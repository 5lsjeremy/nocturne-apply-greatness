//v.01 updated 26.03.18
using Nocturne.Abstractions.Genesis.Lineage;

namespace Nocturne.Genesis.Models.Lineage
{
    public sealed class EmptyProvenance : IProvenance
    {
        public string SeedId { get; init; } = string.Empty;

        public IReadOnlyDictionary<string, string> PromptAnswers { get; init; }
            = new Dictionary<string, string>();

        public IReadOnlyList<string> LlmContributions { get; init; }
            = Array.Empty<string>();

        public IReadOnlyList<string> BuilderContributions { get; init; }
            = Array.Empty<string>();

        public IReadOnlyList<string> InferenceRulesApplied { get; init; }
            = Array.Empty<string>();

        public DateTime Timestamp { get; init; } = DateTime.UtcNow;

        public List<ProvenanceAction> Actions { get; } = new();
    }
}