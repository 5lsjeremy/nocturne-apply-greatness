using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Models;

namespace Nocturne.Genesis.Engine
{
    internal sealed class GenesisInferenceResult : IGenesisInferenceResult
    {
        public Dictionary<string, string> Metadata { get; set; } = new();
        public List<GenesisCard> Cards { get; set; } = new();
        public List<GenesisDeck> Decks { get; set; } = new();
    }
}