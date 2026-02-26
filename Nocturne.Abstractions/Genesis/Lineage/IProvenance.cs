namespace Nocturne.Abstractions.Genesis.Lineage
{
    /// <summary>
    /// Captures the fossil record of an artifact's creation.
    /// Provenance is the serialized trail from seed → prompts → inference → artifact.
    /// This enables replay, regeneration, and contributor trust.
    /// </summary>
    public interface IProvenance
    {
        string SeedId { get; }
        IReadOnlyDictionary<string, string> PromptAnswers { get; }
        IReadOnlyList<string> LlmContributions { get; }
        IReadOnlyList<string> BuilderContributions { get; }
        IReadOnlyList<string> InferenceRulesApplied { get; }
        DateTime Timestamp { get; }
    }
}