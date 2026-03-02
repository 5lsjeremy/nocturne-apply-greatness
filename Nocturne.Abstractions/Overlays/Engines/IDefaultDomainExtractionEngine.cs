namespace Nocturne.Abstractions.Overlays.Engines
{
    public interface IDefaultDomainExtractionEngine
    {
        IDomainExtractionOutput Extract(IDomainExtractionInput input);
    }

    public interface IDefaultCardExtractionEngine
    {
        ICardExtractionOutput Extract(ICardExtractionInput input);
    }

    public interface IDefaultWorkOrderEngine
    {
        IWorkOrderOutput Generate(IWorkOrderInput input);
    }

    public interface IDefaultDomainEnrichmentEngine
    {
        IDomainEnrichmentOutput Enrich(IDomainEnrichmentInput input);
    }

    public interface IDefaultCardEnrichmentEngine
    {
        ICardEnrichmentOutput Enrich(ICardEnrichmentInput input);
    }

    public interface IDefaultPitfallEngine
    {
        IPitfallOutput Frame(IPitfallInput input);
    }

    public interface IDefaultQuestionEngine
    {
        IQuestionOutput Frame(IQuestionInput input);
    }

    public interface IDefaultReactionEngine
    {
        IReactionOutput Simulate(IReactionInput input);
    }
}