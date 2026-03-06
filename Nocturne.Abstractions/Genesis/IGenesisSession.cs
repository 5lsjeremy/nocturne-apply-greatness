using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisSession
    {
        string SeedId { get; }
        DateTime Timestamp { get; }
        IReadOnlyList<ICard> Cards { get; }
        IStarterDeck StarterDeck { get; }

        // The evaluated concept that inference was based on
        IConcept Concept { get; }

        // Full diagnostic trace from concept evaluation (projection of Concept.Metadata.Logs)
        IReadOnlyCollection<ISurfaceLogEntry> ConceptLogs { get; }

        ICard? GetCardById(string id);
    }
}