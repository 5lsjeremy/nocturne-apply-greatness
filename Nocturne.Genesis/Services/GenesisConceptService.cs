using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Services
{
    internal sealed class GenesisConceptService : IConceptService
    {
        private readonly ILlmConceptGenerator _llm;

        public GenesisConceptService(ILlmConceptGenerator llm)
        {
            _llm = llm;
        }

        public async Task<IConcept> EvaluateAsync(string worldConcept)
        {
            // Call the LLM to generate the structured concept DTO
            LlmConceptResponse dto = await _llm.GenerateConceptAsync(worldConcept);

            // Wrap the DTO in the new concept wrapper
            return new ConceptFromDto(dto);
        }
    }
}