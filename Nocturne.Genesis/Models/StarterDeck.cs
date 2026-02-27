using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Enums;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Genesis.Nocturne.Abstractions.Decks;

namespace Nocturne.Genesis.Models
{
    internal sealed class StarterDeck : IStarterDeck
    {
        public string Name { get; internal set; } = "Starter Deck";

        // Internal mutable list
        public List<ICard> Cards { get; } = new();
        IReadOnlyList<ICard> IDeck.Cards => Cards;

        // Internal mutable metadata
        public Dictionary<string, object> Metadata { get; } = new();
        IReadOnlyDictionary<string, object> IDeck.Metadata => Metadata;

        // Lineage (internal setter)
        public IDeckLineage Lineage { get; internal set; }

        // Approval state
        public CardStatusDetails.ArtifactState State { get; internal set; }
            = CardStatusDetails.ArtifactState.Draft;
    }
}