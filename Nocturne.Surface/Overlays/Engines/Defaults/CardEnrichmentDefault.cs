using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;

namespace Nocturne.Surface.Overlays.Engines.Defaults
{
    public sealed class CardEnrichmentDefault : ICardEnrichmentEngine
    {
        public ICardEnrichmentOutput Execute(ICardEnrichmentInput input)
            => new CardEnrichmentOutput();
    }
}