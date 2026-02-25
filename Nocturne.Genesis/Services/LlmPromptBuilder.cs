using System.Text;
using Nocturne.Genesis.Engine;
using Nocturne.Genesis.Models;
using Nocturne.Genesis.Prompts;

namespace Nocturne.Genesis.Services
{
    internal sealed class LlmPromptBuilder : ILlmPromptBuilder
    {
        public string Build(PromptQuestion question, GenesisContext context, PromptLocalization localization)
        {
            var sb = new StringBuilder();

            sb.AppendLine("You are helping shape a world for a deck-based simulation engine.");
            sb.AppendLine("Use the builder's answers to enrich the world description.");
            sb.AppendLine();
            sb.AppendLine($"Question Id: {question.Id}");
            sb.AppendLine($"Axes: {string.Join(", ", question.Axes)}");
            sb.AppendLine();

            if (context.Answers.TryGetValue(question.Id, out var raw))
            {
                sb.AppendLine("Builder prompt and response:");
                sb.AppendLine(raw?.ToString());
            }

            sb.AppendLine();
            sb.AppendLine("Template:");
            sb.AppendLine(question.LlmPromptTemplate);

            return sb.ToString();
        }
    }
}