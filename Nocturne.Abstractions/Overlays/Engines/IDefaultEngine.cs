namespace Nocturne.Abstractions.Overlays.Engines;

public interface IDefaultEngine<TInput, TOutput>
    where TInput : IOverlayEngineInput
{
    TOutput Execute(TInput input);
}

public interface IDomainExtractionEngine 
    : IDefaultEngine<IDomainExtractionInput, IDomainExtractionOutput> { }

public interface ICardExtractionEngine 
    : IDefaultEngine<ICardExtractionInput, ICardExtractionOutput> { }

public interface IWorkOrderEngine 
    : IDefaultEngine<IWorkOrderInput, IWorkOrderOutput> { }

public interface IDomainEnrichmentEngine 
    : IDefaultEngine<IDomainEnrichmentInput, IDomainEnrichmentOutput> { }

public interface ICardEnrichmentEngine 
    : IDefaultEngine<ICardEnrichmentInput, ICardEnrichmentOutput> { }

public interface IPitfallEngine 
    : IDefaultEngine<IPitfallInput, IPitfallOutput> { }

public interface IQuestionEngine 
    : IDefaultEngine<IQuestionInput, IQuestionOutput> { }

public interface IReactionEngine 
    : IDefaultEngine<IReactionInput, IReactionOutput> { }
