using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IWorldContext
    {
        IDomainState DomainState { get; }
        WorldFlags Flags { get; }

        // Optional: card or stamina systems
        ISparkDeck SparkDeck { get; }
        IPressureDeck PressureDeck { get; }
    }
}