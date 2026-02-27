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

        public void AppendAction(
            IProvenance provenance,
            string action,
            string actor,
            int previousVersion,
            string? reason = null,
            string? prompt = null)
        {
            var concrete = (GenesisProvenance)provenance;

            concrete.Actions.Add(new ProvenanceAction
            {
                Action = action,
                Actor = actor,
                PreviousVersion = previousVersion,
                Reason = reason,
                Prompt = prompt,
                Timestamp = DateTime.UtcNow
            });
        }

    }
}