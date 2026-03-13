using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisLlmClient
    {
        Task<string> CompleteAsync(string prompt, LlmTaskType task);
    }
}