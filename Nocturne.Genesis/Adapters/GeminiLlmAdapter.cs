using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;
using System.Text.Json;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Adapters
{
    internal sealed class GeminiLlmAdapter : IGenesisWorldLlmAdapter
    {
        private readonly IGenesisLlmClient _client;

        public GeminiLlmAdapter(IGenesisLlmClient client)
        {
            _client = client;
        }

        // ------------------------------------------------------------
        // UNIFIED WORLD PACKAGE
        // ------------------------------------------------------------
        public async Task<LlmWorldPackageResponse> GenerateWorldPackageAsync(
            IGenesisContext context,
            IOverlayTags? tags,
            CancellationToken ct = default)
        {
            var effectiveTags = tags ?? context.OverlayTags;
            var prompt = context.BuildUnifiedWorldPackagePrompt(effectiveTags);

            var raw = await _client.CompleteAsync(prompt, LlmTaskType.Synthesis);
            var json = CleanJson(raw);

            return Deserialize<LlmWorldPackageResponse>(json, raw, "world package");
        }

        // ------------------------------------------------------------
        // JSON SANITIZATION
        // ------------------------------------------------------------
        private static string CleanJson(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return "{}";

            var cleaned = raw.Trim();

            cleaned = cleaned
                .Replace("```json", "", StringComparison.OrdinalIgnoreCase)
                .Replace("```", "")
                .Trim('`')
                .Trim();

            int first = cleaned.IndexOf('{');
            int last = cleaned.LastIndexOf('}');
            if (first >= 0 && last > first)
                cleaned = cleaned.Substring(first, last - first + 1);

            return cleaned;
        }

        // ------------------------------------------------------------
        // DESERIALIZATION WITH ERROR CONTEXT
        // ------------------------------------------------------------
        private static T Deserialize<T>(string json, string raw, string label)
        {
            try
            {
                var dto = JsonSerializer.Deserialize<T>(json);
                if (dto == null)
                    throw new InvalidOperationException($"LLM returned null {label} DTO.");

                return dto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Failed to parse {label} JSON.\nRAW:\n{raw}\nCLEANED:\n{json}",
                    ex
                );
            }
        }
    }
}