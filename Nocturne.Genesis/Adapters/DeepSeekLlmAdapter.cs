using System.Text.Json;
using System.Text.RegularExpressions;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO;

namespace Nocturne.Genesis.Adapters
{
    public sealed class DeepSeekLlmAdapter : IGenesisWorldLlmAdapter
    {
        private readonly DeepSeekLlmClient _client;

        public DeepSeekLlmAdapter(DeepSeekLlmClient client)
        {
            _client = client;
        }

        public async Task<LlmWorldPackageResponse> GenerateWorldPackageAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default)
        {
            // Build the unified world-package prompt
            var prompt = context.BuildUnifiedWorldPackagePrompt(tags);

            // Call DeepSeek using the synthesis task
            var raw = await _client.CompleteAsync(prompt, LlmTaskType.Synthesis);

            // Extract JSON (DeepSeek sometimes wraps output)
            var json = ExtractJsonBlock(raw);

            // Deserialize into the unified DTO
            var package = JsonSerializer.Deserialize<LlmWorldPackageResponse>(json);

            if (package is null)
                throw new InvalidOperationException(
                    $"DeepSeek returned invalid world package JSON.\nRaw:\n{raw}");

            return package;
        }

        private static string ExtractJsonBlock(string raw)
        {
            // Fast path: already valid JSON
            raw = raw.Trim();
            if (raw.StartsWith("{") && raw.EndsWith("}"))
                return raw;

            // Try to extract the first {...} block
            var match = Regex.Match(raw, "{[\\s\\S]*}");
            if (match.Success)
                return match.Value;

            throw new InvalidOperationException(
                "DeepSeek response did not contain a valid JSON object.");
        }
    }
}