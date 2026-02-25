using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Engine;
using Nocturne.Genesis.Models;

namespace Nocturne.Genesis.Builders
{
    internal sealed class GenesisBuilder : IGenesisBuilder
    {
        private readonly DeckBuilder _deckBuilder;
        private readonly CardBuilder _cardBuilder;
        private readonly GenesisMetadataBuilder _metadataBuilder;

        public GenesisBuilder(
            DeckBuilder deckBuilder,
            CardBuilder cardBuilder,
            GenesisMetadataBuilder metadataBuilder)
        {
            _deckBuilder = deckBuilder;
            _cardBuilder = cardBuilder;
            _metadataBuilder = metadataBuilder;
        }

        public IStarterDeck BuildStarterDeck(IGenesisContext context)
        {
            var concreteContext = (GenesisContext)context;

            var deck = _deckBuilder.CreateDeck("StarterDeck");

            foreach (var card in concreteContext.Cards)
            {
                deck.MutableCards.Add(card);
            }

            deck.MutableMetadata = _metadataBuilder.Build(concreteContext);

            return deck;
        }
    }
}