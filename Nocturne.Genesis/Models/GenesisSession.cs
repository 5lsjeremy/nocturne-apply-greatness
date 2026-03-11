using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Enums;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.SurfaceDTO;

namespace Nocturne.Genesis.Models
{
    internal sealed class GenesisSession : IGenesisSession
    {
        public string SeedId { get; init; } = string.Empty;
        public DateTime Timestamp { get; init; }

        public SurfaceDTO World { get; init; } = default!;

        public IConcept Concept { get; init; } = default!;

        public IReadOnlyCollection<ISurfaceLogEntry> ConceptLogs
            => Concept.Metadata.Logs;

        public IReadOnlyList<ICard> Cards { get; init; } = Array.Empty<ICard>();

        public IStarterDeck StarterDeck { get; init; } = new EmptyStarterDeck();

        public string InferenceRunId { get; init; } = string.Empty;

        public IReadOnlyDictionary<string, string> PromptAnswers { get; init; }
            = new Dictionary<string, string>();

        private sealed class EmptyStarterDeck : IStarterDeck
        {
            public string Name => "Empty Deck";
            public IReadOnlyList<ICard> Cards => Array.Empty<ICard>();
            public IReadOnlyDictionary<string, object> Metadata { get; }
            public IDeckLineage Lineage { get; }
            public CardStatusDetails.ArtifactState State { get; }
        }
    }
}