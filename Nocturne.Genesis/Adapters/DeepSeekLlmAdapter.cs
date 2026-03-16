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

            // Repair malformed JSON (unclosed arrays, objects, trailing commas)
            json = JsonRepair.TryRepair(json);

            // Deserialize into the unified DTO
            var package = JsonSerializer.Deserialize<LlmWorldPackageResponse>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );


            if (package is null)
                throw new InvalidOperationException(
                    $"DeepSeek returned invalid world package JSON.\nRaw:\n{raw}\nRepaired:\n{json}");

            return package;
        }

        private static string ExtractJsonBlock(string raw)
        {
            raw = raw.Trim();

            // Fast path: already valid JSON object
            if (raw.StartsWith("{") && raw.EndsWith("}"))
                return raw;

            // Extract the first {...} block
            var match = Regex.Match(raw, "{[\\s\\S]*}");
            if (match.Success)
                return match.Value;

            throw new InvalidOperationException(
                "DeepSeek response did not contain a valid JSON object.");
        }
    }

    internal static class JsonRepair
    {
        public static string TryRepair(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            input = input.Trim();

            // Remove trailing commas
            while (input.EndsWith(","))
                input = input.Substring(0, input.Length - 1).TrimEnd();

            // Count braces/brackets
            int openBraces = input.Count(c => c == '{');
            int closeBraces = input.Count(c => c == '}');
            int openBrackets = input.Count(c => c == '[');
            int closeBrackets = input.Count(c => c == ']');

            // Close missing braces
            while (closeBraces < openBraces)
            {
                input += "}";
                closeBraces++;
            }

            // Close missing brackets
            while (closeBrackets < openBrackets)
            {
                input += "]";
                closeBrackets++;
            }

            return input;
        }
    }
}