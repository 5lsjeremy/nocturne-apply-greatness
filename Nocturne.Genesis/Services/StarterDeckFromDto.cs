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
            dto ??= new LlmStarterDeckResponse();

            Name = dto.Title ?? string.Empty;
            Summary = dto.Summary ?? string.Empty;
            CardIds = dto.CardIds?.ToList() ?? new List<string>();
            Tags = dto.Tags?.ToList() ?? new List<string>();

            Cards = Array.Empty<ICard>();
            Metadata = new Dictionary<string, object>();
            Lineage = DeckLineage.Empty;
            State = CardStatusDetails.ArtifactState.Generated;
        }
    }
}