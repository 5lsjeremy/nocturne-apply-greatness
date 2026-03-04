using System.Text;
using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Models;
using Nocturne.Genesis.Prompts;

namespace Nocturne.Genesis.Services
{
    internal sealed class LlmPromptBuilder : ILlmPromptBuilder
    {
        public string Build(PromptQuestion question, IGenesisContext context, PromptLocalization localization)
        {
            var sb = new StringBuilder();

            sb.AppendLine("You are helping shape a world for a deck-based simulation engine.");
            sb.AppendLine("Use the builder's answers and the evaluated concept metadata to enrich the world description.");
            sb.AppendLine();

            // Concept metadata
            sb.AppendLine("=== Concept Metadata ===");
            sb.AppendLine($"World Concept: {context.Concept.WorldConcept}");
            sb.AppendLine($"Clarity: {(context.Concept.IsClear == true ? "clear" : "unclear")}");
            sb.AppendLine($"Pitch: {context.Concept.Pitch ?? "(none)"}");

            if (context.Concept.Tags != null)
            {
                sb.AppendLine($"Tags: tone={context.Concept.Tags.Tone}, density={context.Concept.Tags.Density}, risk={context.Concept.Tags.Risk}");
            }
            else
            {
                sb.AppendLine("Tags: (none)");
            }

            sb.AppendLine();
            sb.AppendLine("=== Question ===");
            sb.AppendLine($"Question Id: {question.Id}");
            sb.AppendLine($"Axes: {string.Join(", ", question.Axes)}");
            sb.AppendLine();

            // Builder prompt + response
            if (context.Answers.TryGetValue(question.Id, out var raw))
            {
                sb.AppendLine("Builder prompt and response:");
                sb.AppendLine(raw?.ToString());
            }

            sb.AppendLine();
            sb.AppendLine("=== Template ===");
            sb.AppendLine(question.LlmPromptTemplate);

            return sb.ToString();
        }
    }
}