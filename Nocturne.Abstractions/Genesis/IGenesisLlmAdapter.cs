using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisLlmAdapter
    {
        Task EvaluateClarityAsync(IConceptBuilder concept);
        Task GeneratePitchAsync(IConceptBuilder concept);
        Task InferTagsAsync(IConceptBuilder concept);

        Task<string> GenerateRawAsync(string prompt);
    }
}