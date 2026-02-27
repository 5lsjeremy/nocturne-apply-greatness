using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Genesis.Nocturne.Abstractions.Decks;

namespace Nocturne.Abstractions.Genesis
{
    public interface IStarterDeck : IDeck
    {
        IDeckLineage Lineage { get; }
    }
}