using Nocturne.Abstractions.Overlays;

namespace Nocturne.Surface.Overlays
{
    public sealed class CompositeOverlay : IOverlay
    {
        private readonly IOverlay _base;
        private readonly IOverlay _inferred;
        private readonly IOverlay? _custom;

        public CompositeOverlay(IOverlay baseOverlay, IOverlay inferredOverlay, IOverlay? customOverlay = null)
        {
            _base = baseOverlay;
            _inferred = inferredOverlay;
            _custom = customOverlay;
        }

        public IOverlayTags Tags =>
            _custom?.Tags ??
            _inferred.Tags ??
            _base.Tags;

        private TOut Dispatch<TIn, TOut>(
            TIn input,
            Func<IOverlay, TIn, TOut> selector)
        {
            if (_custom != null)
            {
                var customResult = selector(_custom, input);
                if (customResult != null) return customResult;
            }

            var inferredResult = selector(_inferred, input);
            if (inferredResult != null) return inferredResult;

            return selector(_base, input);
        }

        public IDomainExtractionOutput ExtractDomains(IDomainExtractionInput input)
            => Dispatch(input, (o, i) => o.ExtractDomains(i));

        public ICardExtractionOutput ExtractCards(ICardExtractionInput input)
            => Dispatch(input, (o, i) => o.ExtractCards(i));

        public IWorkOrderOutput GenerateWorkOrder(IWorkOrderInput input)
            => Dispatch(input, (o, i) => o.GenerateWorkOrder(i));

        public IDomainEnrichmentOutput EnrichDomain(IDomainEnrichmentInput input)
            => Dispatch(input, (o, i) => o.EnrichDomain(i));

        public ICardEnrichmentOutput EnrichCard(ICardEnrichmentInput input)
            => Dispatch(input, (o, i) => o.EnrichCard(i));

        public IPitfallOutput FramePitfalls(IPitfallInput input)
            => Dispatch(input, (o, i) => o.FramePitfalls(i));

        public IQuestionOutput FrameQuestions(IQuestionInput input)
            => Dispatch(input, (o, i) => o.FrameQuestions(i));

        public IReactionOutput SimulateReactions(IReactionInput input)
            => Dispatch(input, (o, i) => o.SimulateReactions(i));
    }
    
    /// summary
    /// This class merges:
    /// - base overlay
    /// - inferred overlay
    /// - custom overlay
    /// It delegates each method call to the highest‑priority overlay that overrides it.
    /// Priority order:
    /// - Custom overlay
    /// - Inferred overlay
    /// - Base overlay
}