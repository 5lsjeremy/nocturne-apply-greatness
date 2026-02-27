namespace Nocturne.Abstractions.Genesis.Lineage
{
    public interface IProvenanceService
    {
        IProvenance CreateProvenance(
            string seedId,
            IDictionary<string, string> promptAnswers,
            IEnumerable<string> llm,
            IEnumerable<string> builder,
            IEnumerable<string> rules);

        void AppendAction(
            IProvenance provenance,
            string action,
            string actor,
            int previousVersion,
            string? reason = null,
            string? prompt = null);
    }
}