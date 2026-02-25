using Nocturne.Genesis.Models;

namespace Nocturne.Genesis.Builders
{
    internal sealed class DeckBuilder
    {
        public StarterDeck CreateDeck(string name)
        {
            return new StarterDeck
            {
                Name = name
            };
        }
    }
}