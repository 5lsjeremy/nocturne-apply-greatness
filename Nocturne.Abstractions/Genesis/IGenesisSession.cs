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

        // NEW — the evaluated concept that inference was based on
        IConcept Concept { get; }

        // NEW — full diagnostic trace from concept evaluation
        IReadOnlyCollection<ISurfaceLogEntry> ConceptLogs { get; }

        ICard? GetCardById(string id);
    }
}