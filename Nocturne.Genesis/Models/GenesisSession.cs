using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Models
{
    internal sealed class GenesisSession : IGenesisSession
    {
        public string SeedId { get; init; } = string.Empty;
        public DateTime Timestamp { get; init; }
        public IReadOnlyList<ICard> Cards { get; init; } = Array.Empty<ICard>();
        public IStarterDeck StarterDeck { get; init; } = default!;

        public ICard? GetCardById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return Cards.FirstOrDefault(c => c.Id == id);
        }
    }
}