using Nocturne.Genesis.Engine;
using Nocturne.Genesis.Models;
using Nocturne.Genesis.Prompts;

namespace Nocturne.Genesis.Services
{
    internal interface ILlmPromptBuilder
    {
        string Build(PromptQuestion question, GenesisContext context, PromptLocalization localization);
    }
}