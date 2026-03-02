namespace Nocturne.Abstractions.Overlays
{
    public interface IOverlay
    {
        IOverlayTags Tags { get; }

        IDomainExtractionOutput ExtractDomains(IDomainExtractionInput input);
        ICardExtractionOutput ExtractCards(ICardExtractionInput input);
        IWorkOrderOutput GenerateWorkOrder(IWorkOrderInput input);

        IDomainEnrichmentOutput EnrichDomain(IDomainEnrichmentInput input);
        ICardEnrichmentOutput EnrichCard(ICardEnrichmentInput input);

        IPitfallOutput FramePitfalls(IPitfallInput input);
        IQuestionOutput FrameQuestions(IQuestionInput input);
        IReactionOutput SimulateReactions(IReactionInput input);
    }
    public interface IOverlayTags
    {
        string Tone { get; }
        string Density { get; }
        string Style { get; }
        string WorldType { get; }
        string Risk { get; }
    }
    public interface IOverlayEngineInput
    {
        IOverlayTags Tags { get; }
    }

    public interface IDomainExtractionInput : IOverlayEngineInput { }
    public interface ICardExtractionInput : IOverlayEngineInput { }
    public interface IWorkOrderInput : IOverlayEngineInput { }
    public interface IDomainEnrichmentInput : IOverlayEngineInput { }
    public interface ICardEnrichmentInput : IOverlayEngineInput { }
    public interface IPitfallInput : IOverlayEngineInput { }
    public interface IQuestionInput : IOverlayEngineInput { }
    public interface IReactionInput : IOverlayEngineInput { }

    public interface IDomainExtractionOutput { }
    public interface ICardExtractionOutput { }
    public interface IWorkOrderOutput { }
    public interface IDomainEnrichmentOutput { }
    public interface ICardEnrichmentOutput { }
    public interface IPitfallOutput { }
    public interface IQuestionOutput { }
    public interface IReactionOutput { }


}