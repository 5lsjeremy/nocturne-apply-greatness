using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Genesis.Models
{
    internal sealed class GenesisSession : IGenesisSession
    {
        public string SeedId { get; init; } = string.Empty;
        public DateTime Timestamp { get; init; }

        public IReadOnlyList<ICard> Cards { get; init; } = Array.Empty<ICard>();
        public IStarterDeck StarterDeck { get; init; } = default!;

        public string InferenceRunId { get; init; } = string.Empty;

        public IReadOnlyDictionary<string, string> PromptAnswers { get; init; }
            = new Dictionary<string, string>();

        public IConcept Concept { get; init; } = default!;

        // Projection of Concept.Metadata.Logs
        public IReadOnlyCollection<ISurfaceLogEntry> ConceptLogs
            => Concept.Metadata.Logs;

        public ICard? GetCardById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return Cards.FirstOrDefault(c => c.Id == id);
        }
    }
}