using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Prompts;

namespace Nocturne.Genesis.Services
{
    internal interface ILlmPromptBuilder
    {
        string Build(
            PromptQuestion question,
            IGenesisContext context,
            PromptLocalization localization);
    }
}