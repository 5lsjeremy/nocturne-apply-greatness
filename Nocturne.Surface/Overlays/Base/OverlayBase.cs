using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;
using Nocturne.Surface.Overlays.Tags;

namespace Nocturne.Surface.Overlays.Base
{
    public abstract class OverlayBase : IOverlay
    {
        public IOverlayTags Tags { get; }

        protected readonly IDomainExtractionEngine DomainExtraction;
        protected readonly ICardExtractionEngine CardExtraction;
        protected readonly IWorkOrderEngine WorkOrder;
        protected readonly IDomainEnrichmentEngine DomainEnrichment;
        protected readonly ICardEnrichmentEngine CardEnrichment;
        protected readonly IPitfallEngine Pitfalls;
        protected readonly IQuestionEngine Questions;
        protected readonly IReactionEngine Reactions;

        protected OverlayBase(
            IOverlayTags? tags,
            IDomainExtractionEngine domainExtraction,
            ICardExtractionEngine cardExtraction,
            IWorkOrderEngine workOrder,
            IDomainEnrichmentEngine domainEnrichment,
            ICardEnrichmentEngine cardEnrichment,
            IPitfallEngine pitfalls,
            IQuestionEngine questions,
            IReactionEngine reactions)
        {
            Tags = tags ?? new OverlayTags();

            DomainExtraction = domainExtraction;
            CardExtraction = cardExtraction;
            WorkOrder = workOrder;
            DomainEnrichment = domainEnrichment;
            CardEnrichment = cardEnrichment;
            Pitfalls = pitfalls;
            Questions = questions;
            Reactions = reactions;
        }

        public virtual IDomainExtractionOutput ExtractDomains(IDomainExtractionInput input)
            => DomainExtraction.Execute(input);

        public virtual ICardExtractionOutput ExtractCards(ICardExtractionInput input)
            => CardExtraction.Execute(input);

        public virtual IWorkOrderOutput GenerateWorkOrder(IWorkOrderInput input)
            => WorkOrder.Execute(input);

        public virtual IDomainEnrichmentOutput EnrichDomain(IDomainEnrichmentInput input)
            => DomainEnrichment.Execute(input);

        public virtual ICardEnrichmentOutput EnrichCard(ICardEnrichmentInput input)
            => CardEnrichment.Execute(input);

        public virtual IPitfallOutput FramePitfalls(IPitfallInput input)
            => Pitfalls.Execute(input);

        public virtual IQuestionOutput FrameQuestions(IQuestionInput input)
            => Questions.Execute(input);

        public virtual IReactionOutput SimulateReactions(IReactionInput input)
            => Reactions.Execute(input);
    }
}