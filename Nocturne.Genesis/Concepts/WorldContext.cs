using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class WorldContext : IWorldContext
    {
        public IDomainState DomainState { get; init; }
        public ISparkDeck SparkDeck { get; init; }
        public IPressureDeck PressureDeck { get; init; }
        public WorldFlags Flags { get; set; }

        public WorldContext(
            IDomainState domainState,
            ISparkDeck sparkDeck,
            IPressureDeck pressureDeck,
            WorldFlags flags = WorldFlags.None)
        {
            DomainState = domainState;
            SparkDeck = sparkDeck;
            PressureDeck = pressureDeck;
            Flags = flags;
        }
    }
}