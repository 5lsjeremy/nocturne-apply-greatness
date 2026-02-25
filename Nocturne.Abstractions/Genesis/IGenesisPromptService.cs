namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisPromptService
    {
        void RunMvpLoop(IGenesisContext context);
    }
}