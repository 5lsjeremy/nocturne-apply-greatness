using System.Text.Json;
using System.Text.Json.Serialization;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Surface.Exceptions;
using Nocturne.Surface.Overlays.Tags;

namespace Nocturne.Genesis.Adapters
{
    internal sealed class GeminiLlmAdapter : IGenesisLlmAdapter
    {
        private readonly IGenesisLlmClient _client;

        public GeminiLlmAdapter(IGenesisLlmClient client)
        {
            _client = client;
        }

        public async Task EvaluateClarityAsync(IConceptBuilder concept)
        {
            var prompt = $@"
You are a concept‑clarity evaluator. Analyze the following world concept
and return a JSON object with fields: isClear (true/false), reason (string).

CONCEPT:
{concept.WorldConcept}

Respond ONLY with JSON.
";

            var json = await _client.CompleteAsync(prompt);

            // Strip code fences if present
            json = json.Trim();
            if (json.StartsWith("```"))
            {
                var start = json.IndexOf('{');
                var end = json.LastIndexOf('}');
                json = json.Substring(start, end - start + 1);
            }

            // Parse JSON into a DTO
            var result = JsonSerializer.Deserialize<ClarityResult>(json);

            if (result == null)
                throw new InvalidConceptException("LLM returned invalid clarity JSON.");

            // Apply to the concept builder
            concept.SetClarity(
                result.IsClear,
                new[] { result.Reason },   // treat the reason as a single recommendation
                Array.Empty<string>()      // no questions for now
            );

        }


        public async Task GeneratePitchAsync(IConceptBuilder concept)
        {
            var prompt = $@"
You are a pitch generator. Produce a concise, compelling pitch for the
following world concept. Respond with JSON containing: pitch (string).

CONCEPT:
{concept.WorldConcept}

Respond ONLY with JSON.
";

            var json = await _client.CompleteAsync(prompt);

            // Strip code fences if present
            json = json.Trim();
            if (json.StartsWith("```"))
            {
                var start = json.IndexOf('{');
                var end = json.LastIndexOf('}');
                json = json.Substring(start, end - start + 1);
            }

            var result = JsonSerializer.Deserialize<PitchResult>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (result == null || string.IsNullOrWhiteSpace(result.Pitch))
                throw new InvalidConceptException("LLM returned invalid pitch JSON.");

            concept.SetPitch(
                result.Pitch,
                Array.Empty<string>() // no recommendations yet
            );
        }





        public async Task InferTagsAsync(IConceptBuilder concept)
        {
            var prompt = $@"
You are a tag inference engine. Infer overlay tags for the following world concept.
Return JSON with the following fields:

- tone: string
- density: string
- style: string
- worldType: string
- risk: string

CONCEPT:
{concept.WorldConcept}

Respond ONLY with JSON.
";

            var json = await _client.CompleteAsync(prompt);

            // Strip code fences
            json = json.Trim();
            if (json.StartsWith("```"))
            {
                var start = json.IndexOf('{');
                var end = json.LastIndexOf('}');
                json = json.Substring(start, end - start + 1);
            }

            var result = JsonSerializer.Deserialize<OverlayTagResult>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (result == null)
                throw new InvalidConceptException("LLM returned invalid tag JSON.");

            var overlayTags = new OverlayTags(
                tone: result.Tone ?? "neutral",
                density: result.Density ?? "medium",
                style: result.Style ?? "literal",
                worldType: result.WorldType ?? "generic",
                risk: result.Risk ?? "medium"
            );

            concept.SetTags(
                overlayTags,
                Array.Empty<string>()
            );
        }

        public sealed class OverlayTagResult
        {
            [JsonPropertyName("tone")]
            public string? Tone { get; set; }

            [JsonPropertyName("density")]
            public string? Density { get; set; }

            [JsonPropertyName("style")]
            public string? Style { get; set; }

            [JsonPropertyName("worldType")]
            public string? WorldType { get; set; }

            [JsonPropertyName("risk")]
            public string? Risk { get; set; }
        }
        
        public Task<string> GenerateRawAsync(string prompt)
            => _client.CompleteAsync(prompt);
    }

    public sealed class ClarityResult
    {
        [JsonPropertyName("isClear")]
        public bool IsClear { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; } = "";
    }

    public sealed class PitchResult
    {
        [JsonPropertyName("pitch")]
        public string? Pitch { get; set; }
    }
}