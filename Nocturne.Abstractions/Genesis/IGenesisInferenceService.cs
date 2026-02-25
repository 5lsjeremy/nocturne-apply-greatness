namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisInferenceService
    {
        IGenesisInferenceResult Infer(IGenesisContext context);
    }
}