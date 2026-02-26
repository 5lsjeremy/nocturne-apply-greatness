namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisInferenceResult
    {
        IReadOnlyDictionary<string, object> Metadata { get; }
        IReadOnlyList<ICard> Cards { get; }
        IStarterDeck StarterDeck { get; }
    }
}