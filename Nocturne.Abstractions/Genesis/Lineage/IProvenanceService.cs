namespace Nocturne.Abstractions.Genesis.Lineage
{
    /// <summary>
    /// Creates provenance records for artifacts.
    /// Provenance is the backbone of replay and regeneration.
    /// </summary>
    public interface IProvenanceService
    {
        IProvenance CreateProvenance(string seedId, IDictionary<string, string> promptAnswers, IEnumerable<string> llm, IEnumerable<string> builder, IEnumerable<string> rules);
    }
}