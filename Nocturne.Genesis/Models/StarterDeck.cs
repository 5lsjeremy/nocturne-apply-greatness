using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Models
{
    internal sealed class StarterDeck : IStarterDeck
    {
        public string Name { get; init; } = "Starter Deck";
        public IReadOnlyList<ICard> Cards { get; init; } = Array.Empty<ICard>();
        public IReadOnlyDictionary<string, object> Metadata { get; init; }
            = new Dictionary<string, object>();
    }
}