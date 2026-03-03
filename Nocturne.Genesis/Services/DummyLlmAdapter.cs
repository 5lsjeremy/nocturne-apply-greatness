using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Surface.Overlays.Tags;

internal sealed class DummyLlmAdapter : IGenesisLlmAdapter
{
    public Task EvaluateClarityAsync(IConceptBuilder concept)
    {
        concept.SetClarity(true, Array.Empty<string>(), Array.Empty<string>());
        return Task.CompletedTask;
    }

    public Task GeneratePitchAsync(IConceptBuilder concept)
    {
        concept.SetPitch($"Dummy pitch for: {concept.WorldConcept}", Array.Empty<string>());
        return Task.CompletedTask;
    }

    public Task InferTagsAsync(IConceptBuilder concept)
    {
        concept.SetTags(
            new OverlayTags("neutral", "medium", "literal", "generic", "medium"),
            Array.Empty<string>()
        );
        return Task.CompletedTask;
    }

    public Task<string> GenerateRawAsync(string prompt)
    {
        var result = $"[LLM_ENRICHED]: {prompt.Substring(0, Math.Min(prompt.Length, 200))}...";
        return Task.FromResult(result);
    }
}