using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Engine
{
    internal sealed class GenesisInferenceResult : IGenesisInferenceResult
    {
        public Dictionary<string, object> Metadata { get; set; } = new();
        public List<ICard> Cards { get; set; } = new();
        public IStarterDeck StarterDeck { get; set; } = default!;

        IReadOnlyDictionary<string, object> IGenesisInferenceResult.Metadata => Metadata;
        IReadOnlyList<ICard> IGenesisInferenceResult.Cards => Cards;
    }
}