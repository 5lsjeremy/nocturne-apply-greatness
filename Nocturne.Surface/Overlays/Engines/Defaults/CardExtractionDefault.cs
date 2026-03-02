using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;

namespace Nocturne.Surface.Overlays.Engines.Defaults
{
    public sealed class CardExtractionDefault : ICardExtractionEngine
    {
        public ICardExtractionOutput Execute(ICardExtractionInput input)
            => new CardExtractionOutput();
    }
}