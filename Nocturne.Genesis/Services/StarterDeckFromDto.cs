using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Enums;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Genesis.Models.Lineage;

namespace Nocturne.Genesis.Models
{
    internal sealed class StarterDeckFromDto : IStarterDeck
    {
        public string Name { get; }
        public string Summary { get; }
        public IReadOnlyList<string> CardIds { get; }
        public IReadOnlyList<string> Tags { get; }

        // Required by IStarterDeck
        public IReadOnlyList<ICard> Cards { get; }
        public IReadOnlyDictionary<string, object> Metadata { get; }
        public IDeckLineage Lineage { get; }
        public CardStatusDetails.ArtifactState State { get; }

        public StarterDeckFromDto(LlmStarterDeckResponse dto)
        {
            Name = dto.Title ?? string.Empty;
            Summary = dto.Summary ?? string.Empty;
            CardIds = dto.CardIds?.ToList() ?? new List<string>();
            Tags = dto.Tags?.ToList() ?? new List<string>();

            // Decks in the unified DTO contain only card IDs, not card objects.
            // So we expose an empty list here; the builder will resolve cards later.
            Cards = Array.Empty<ICard>();

            // No metadata in the DTO, so provide an empty dictionary.
            Metadata = new Dictionary<string, object>();

            // No lineage in the DTO; provide a safe empty lineage object.
            Lineage = DeckLineage.Empty;

            // Decks produced by inference are always "Generated" state.
            State = CardStatusDetails.ArtifactState.Generated;
        }
    }
}