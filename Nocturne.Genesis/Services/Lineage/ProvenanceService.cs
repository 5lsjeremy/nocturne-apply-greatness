using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Genesis.Models.Lineage;

namespace Nocturne.Genesis.Services.Lineage
{
    public class ProvenanceService : IProvenanceService
    {
        public IProvenance CreateProvenance(string seedId, IDictionary<string, string> promptAnswers, IEnumerable<string> llm, IEnumerable<string> builder, IEnumerable<string> rules)
        {
            return new GenesisProvenance
            {
                SeedId = seedId,
                PromptAnswers = new Dictionary<string, string>(promptAnswers),
                LlmContributions = llm.ToList(),
                BuilderContributions = builder.ToList(),
                InferenceRulesApplied = rules.ToList(),
                Timestamp = DateTime.UtcNow
            };
        }
    }
}