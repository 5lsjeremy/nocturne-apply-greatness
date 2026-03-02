using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;

namespace Nocturne.Surface.Overlays.Engines.Defaults
{
    public sealed class DomainEnrichmentDefault : IDomainEnrichmentEngine
    {
        public IDomainEnrichmentOutput Execute(IDomainEnrichmentInput input)
            => new DomainEnrichmentOutput();
    }
}