using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Nocturne.Abstractions.Decks;

namespace Nocturne.Genesis.Models
{
    internal sealed class GenesisDeck : IDeck
    {
        public string Name { get; init; } = string.Empty;
        public IReadOnlyList<ICard> Cards { get; init; } = Array.Empty<ICard>();
        public IReadOnlyDictionary<string, object> Metadata { get; init; }
            = new Dictionary<string, object>();
    }
}