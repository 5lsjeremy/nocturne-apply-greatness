using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;

namespace Nocturne.Abstractions.Genesis.Concepts;

public interface ILlmConceptGenerator
{
    Task<LlmConceptResponse> GenerateConceptAsync(string worldConcept);
}