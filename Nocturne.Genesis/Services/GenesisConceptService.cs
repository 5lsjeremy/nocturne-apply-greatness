using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Genesis.Builders;

namespace Nocturne.Genesis.Services
{
    internal sealed class GenesisConceptService : IConceptService
    {
        private readonly IGenesisLlmAdapter _llm;

        public GenesisConceptService(IGenesisLlmAdapter llm)
        {
            _llm = llm;
        }

        public async Task<IConcept> EvaluateAsync(string worldConcept)
        {
            var builder = new ConceptBuilder(worldConcept);

            await _llm.EvaluateClarityAsync(builder);
            if (builder.IsClear == false)
            {
                builder.MarkFailure("Concept too vague");
                return builder.Build();
            }

            await _llm.GeneratePitchAsync(builder);
            if (builder.Pitch == null)
            {
                builder.MarkFailure("Unable to generate pitch");
                return builder.Build();
            }

            await _llm.InferTagsAsync(builder);
            if (builder.Tags == null)
            {
                builder.MarkFailure("Unable to infer tags");
                return builder.Build();
            }

            builder.MarkSuccess();
            return builder.Build();
        }
    }
}