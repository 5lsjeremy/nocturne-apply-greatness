using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Models;

namespace Nocturne.Genesis.Builders
{
    internal sealed class CardBuilder
    {
        public ICard Build(GenesisCard card)
        {
            // GenesisCard already implements ICard, but this gives us a hook
            // if we ever want to wrap or transform.
            return card;
        }
    }
}