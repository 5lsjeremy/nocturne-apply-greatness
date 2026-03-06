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
            var concept = context.Concept;
            var core = concept.Core;
            var eval = concept.Evaluation;
            var extract = concept.Extraction;

            var sb = new StringBuilder();

            sb.AppendLine("You are helping shape a world for a deck-based simulation engine.");
            sb.AppendLine("Use the builder's answers and the evaluated concept metadata to enrich the world description.");
            sb.AppendLine();

            // -----------------------------------------------------------------
            // Concept Metadata
            // -----------------------------------------------------------------
            sb.AppendLine("=== Concept Metadata ===");
            sb.AppendLine($"World Concept: {core.WorldConcept}");
            sb.AppendLine($"Clarity: {(eval.IsClear == true ? "clear" : "unclear")}");
            sb.AppendLine($"Pitch: {core.Pitch ?? "(none)"}");

            if (extract.Tags != null)
            {
                sb.AppendLine(
                    $"Tags: tone={extract.Tags.Tone}, density={extract.Tags.Density}, risk={extract.Tags.Risk}"
                );
            }
            else
            {
                sb.AppendLine("Tags: (none)");
            }

            sb.AppendLine();

            // -----------------------------------------------------------------
            // Question
            // -----------------------------------------------------------------
            sb.AppendLine("=== Question ===");
            sb.AppendLine($"Question Id: {question.Id}");
            sb.AppendLine($"Axes: {string.Join(", ", question.Axes)}");
            sb.AppendLine();

            // -----------------------------------------------------------------
            // Builder prompt + response
            // -----------------------------------------------------------------
            if (context.Answers.TryGetValue(question.Id, out var raw))
            {
                sb.AppendLine("Builder prompt and response:");
                sb.AppendLine(raw?.ToString());
            }

            sb.AppendLine();

            // -----------------------------------------------------------------
            // Template
            // -----------------------------------------------------------------
            sb.AppendLine("=== Template ===");
            sb.AppendLine(question.LlmPromptTemplate);

            return sb.ToString();
        }
    }
}