namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisLlmClient
    {
        Task<string> CompleteAsync(string prompt);
    }
}