using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;
using Nocturne.Surface.Overlays.Tags;

namespace Nocturne.Surface.Overlays.Engines
{
    public sealed class OverlayInferenceEngine
    {
        private readonly IDomainExtractionEngine _domainExtraction;
        private readonly ICardExtractionEngine _cardExtraction;
        private readonly IWorkOrderEngine _workOrder;
        private readonly IDomainEnrichmentEngine _domainEnrichment;
        private readonly ICardEnrichmentEngine _cardEnrichment;
        private readonly IPitfallEngine _pitfalls;
        private readonly IQuestionEngine _questions;
        private readonly IReactionEngine _reactions;

        public OverlayInferenceEngine(
            IDomainExtractionEngine domainExtraction,
            ICardExtractionEngine cardExtraction,
            IWorkOrderEngine workOrder,
            IDomainEnrichmentEngine domainEnrichment,
            ICardEnrichmentEngine cardEnrichment,
            IPitfallEngine pitfalls,
            IQuestionEngine questions,
            IReactionEngine reactions)
        {
            _domainExtraction = domainExtraction;
            _cardExtraction = cardExtraction;
            _workOrder = workOrder;
            _domainEnrichment = domainEnrichment;
            _cardEnrichment = cardEnrichment;
            _pitfalls = pitfalls;
            _questions = questions;
            _reactions = reactions;
        }

        public IOverlay InferOverlay(string worldConcept, string pitch, bool isLens)
        {
            var tags = InferTags(worldConcept, pitch);

            return isLens
                ? new LensOverlay(tags, _domainExtraction, _cardExtraction, _workOrder,
                    _domainEnrichment, _cardEnrichment, _pitfalls, _questions, _reactions)
                : new GenesisOverlay(tags, _domainExtraction, _cardExtraction, _workOrder,
                    _domainEnrichment, _cardEnrichment, _pitfalls, _questions, _reactions);
        }

        private IOverlayTags InferTags(string worldConcept, string pitch)
        {
            // TODO: Replace with LLM inference or heuristic mapping
            return new OverlayTags(
                tone: "neutral",
                density: "medium",
                style: "literal",
                worldType: "generic",
                risk: "medium"
            );
        }
    }
}