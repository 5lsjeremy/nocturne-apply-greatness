using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;
using Nocturne.Surface.Overlays.Base;

namespace Nocturne.Surface.Overlays
{
    public sealed class GenesisOverlay : OverlayBase
    {
        public GenesisOverlay(
            IOverlayTags tags,
            IDomainExtractionEngine domainExtraction,
            ICardExtractionEngine cardExtraction,
            IWorkOrderEngine workOrder,
            IDomainEnrichmentEngine domainEnrichment,
            ICardEnrichmentEngine cardEnrichment,
            IPitfallEngine pitfalls,
            IQuestionEngine questions,
            IReactionEngine reactions)
            : base(tags, domainExtraction, cardExtraction, workOrder,
                domainEnrichment, cardEnrichment, pitfalls, questions, reactions)
        {
        }
    }
}