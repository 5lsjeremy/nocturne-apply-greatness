using System.Text.Json;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;

namespace Nocturne.Genesis.Llm
{
    internal sealed class LlmConceptGenerator : ILlmConceptGenerator
    {
        private readonly IGenesisLlmClient _client;

        public LlmConceptGenerator(IGenesisLlmClient client)
        {
            _client = client;
        }

        public async Task<LlmConceptResponse> GenerateConceptAsync(string worldConcept)
        {
            string prompt = BuildPrompt(worldConcept);

            string raw = await _client.CompleteAsync(prompt);

            // ------------------------------------------------------------
            // 1. SANITIZE RAW LLM OUTPUT
            // ------------------------------------------------------------
            string cleaned = raw.Trim();

            cleaned = cleaned
                .Replace("```json", "", StringComparison.OrdinalIgnoreCase)
                .Replace("```", "")
                .Trim('`')
                .Trim();

            int firstBrace = cleaned.IndexOf('{');
            int lastBrace = cleaned.LastIndexOf('}');
            if (firstBrace >= 0 && lastBrace > firstBrace)
                cleaned = cleaned.Substring(firstBrace, lastBrace - firstBrace + 1);

            // ------------------------------------------------------------
            // 2. DESERIALIZE
            // ------------------------------------------------------------
            LlmConceptResponse? dto = null;

            try
            {
                dto = JsonSerializer.Deserialize<LlmConceptResponse>(cleaned);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Failed to parse LLM JSON.\nRAW:\n{raw}\nCLEANED:\n{cleaned}",
                    ex
                );
            }

            if (dto is null)
                throw new InvalidOperationException("LLM returned null or invalid JSON.");

            // ------------------------------------------------------------
            // 3. ATTACH METADATA
            // ------------------------------------------------------------
            dto = dto with
            {
                RawResponse = raw,
                ParsedResponseJson = cleaned,
                PipelineInterpretation = "LLM → LlmConceptResponse",
                FallbackReason = null
            };

            return dto;
        }

        private static string BuildPrompt(string worldConcept)
        {
            return $@"
You are generating a structured JSON concept for a world-building engine.

STRICT RULES:
- All fields shown as string MUST be JSON strings, NOT arrays.
- Do NOT return arrays for: worldName, summary, coreFantasy, tone, genre,
  setting, playerFantasy, creativeNorthStar, tagline, oneSentencePitch,
  thirtySecondPitch, marketPosition, emotionalHook, playerPromise,
  creativePotential, alignmentWithGenre, expectedComplexity, notes.
- Arrays are ONLY allowed where explicitly shown as [].
- Use ONLY ASCII characters.
- Use ONLY ASCII double quotes ("" "").
- Do NOT use smart quotes, curly quotes, angled quotes, em-dashes, en-dashes,
  accented characters, or any non-ASCII punctuation.

Input concept:
{worldConcept}

Respond ONLY with valid JSON matching this schema:

{{
  ""seedId"": ""string"",
  ""core"": {{
    ""worldName"": ""string"",
    ""summary"": ""string"",
    ""coreFantasy"": ""string"",
    ""tone"": ""string"",
    ""genre"": ""string"",
    ""setting"": ""string"",
    ""playerFantasy"": ""string"",
    ""creativeNorthStar"": ""string""
  }},
  ""clarity"": {{
    ""clarityScore"": 0,
    ""notes"": ""string""
  }},
  ""pitch"": {{
    ""tagline"": ""string"",
    ""oneSentencePitch"": ""string"",
    ""thirtySecondPitch"": ""string"",
    ""marketPosition"": ""string"",
    ""emotionalHook"": ""string"",
    ""playerPromise"": ""string""
  }},
  ""tags"": {{
    ""conceptTagsList"": [""string""],
    ""mechanicTags"": [""string""],
    ""moodTags"": [""string""],
    ""themeTags"": [""string""],
    ""settingTags"": [""string""]
  }},
  ""feasibility"": {{
    ""creativePotential"": ""string"",
    ""alignmentWithGenre"": ""string"",
    ""expectedComplexity"": ""string"",
    ""opportunities"": [""string""],
    ""pitfalls"": [""string""],
    ""productionRisks"": [""string""]
  }}
}}

Respond ONLY with JSON.
";
        }
    }
}