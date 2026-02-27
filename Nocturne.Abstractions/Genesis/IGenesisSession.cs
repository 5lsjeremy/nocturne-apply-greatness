namespace Nocturne.Abstractions.Genesis;

public interface IGenesisSession
{
    string SeedId { get; }
    DateTime Timestamp { get; }
    IReadOnlyList<ICard> Cards { get; }
    IStarterDeck StarterDeck { get; }

    ICard? GetCardById(string id);
}