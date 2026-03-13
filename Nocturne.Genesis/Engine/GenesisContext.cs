using System.Text.Json;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Surface;
using Nocturne.Surface.Overlays.Tags;

namespace Nocturne.Genesis.Engine
{
    public sealed class GenesisContext : IGenesisContext
    {
        public ISurfaceArtifact Seed { get; }
        public IDictionary<string, object?> Answers { get; }
        public IList<ICard> Cards { get; }
        public IOverlayTags? OverlayTags { get; }
        public IConcept Concept { get; set; }
        public ISurfaceLogger Logger { get; }

        public GenesisContext(
            ISurfaceArtifact seed,
            IConcept concept,
            IList<ICard> cards,
            IDictionary<string, object?> answers,
            IOverlayTags? overlayTags,
            ISurfaceLogger logger)
        {
            Seed = seed;
            Concept = concept;
            Cards = cards;
            Answers = answers;
            OverlayTags = overlayTags;
            Logger = logger;
        }

        private static string Serialize(object? obj)
            => JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

public string BuildUnifiedWorldPackagePrompt(IOverlayTags? tags = null)
{
    var overlay = tags ?? OverlayTags ?? new OverlayTags("neutral", "medium", "literal", "generic", "medium");

    return $@"
Generate a unified world package as a single JSON object with the following sections:

- domains        (3–7 domains)
- concept        (core world concept bundle)
- cards          (must be an empty array)
- starterDeck    (must be null)
- presentation   (pitch-ready world summary)

SEED ARTIFACT:
{Seed.WorldConcept}

OVERLAY TAGS:
{Serialize(overlay)}

GLOBAL RULES:
- The ENTIRE output MUST be under 10000 characters.
- If needed, shorten summaries, compress lists, and remove non-essential detail.
- Respond ONLY with valid JSON.
- Use ONLY ASCII characters and standard ASCII double quotes.
- No commentary, markdown, or explanation.
- All arrays and objects must be fully closed and syntactically valid.

DOMAIN RULES:
- Generate 3–7 domains.
- Each domain must represent a major pillar of the world.
- Each domain must include ALL required fields.
- Each domain must have a unique domainId.
- Domain summary MUST be 1–2 sentences maximum.
- Boundaries: 3–5 items.
- Tone: 2–4 words.
- Tags: 3–6 items.
- Opportunities: 3–4 short items.
- Risks: 3–4 short items.
- DriftWarnings: 1–2 items.
- PressureTestSeeds: 1–2 items.
- PrismSeeds: 1–2 items.
- Timestamp: short phrase.

CONCEPT RULES:
- All concept.core fields must be 1–3 sentences each.
- The playerPromise MUST be included and MUST be 1–3 sentences.
- Clarity notes: 1–2 sentences.
- Pitch section MUST include ONLY:
  - tagline
  - oneSentencePitch
  - thirtySecondPitch
  - playerPromise
- Do NOT include marketPosition or emotionalHook.
- Tags lists must be compact (3–6 items each).

FEASIBILITY RULES:
Each subsection MUST be a single expressive sentence:
- creativePotential: one sentence describing creative strength and potential.
- alignmentWithGenre: one sentence describing fit within genre expectations.
- expectedComplexity: one sentence describing system and narrative complexity.
- opportunities: one sentence containing a comma-separated list of opportunities.
- pitfalls: one sentence containing a comma-separated list of pitfalls.
- productionRisks: one sentence containing a comma-separated list of production risks.

PRESENTATION RULES:
- Include ONLY:
  - title
  - subtitle
  - overview (2–4 sentences)
  - pillars (4 short items)
  - recommendedNextSteps (exactly 3 short items)
- Do NOT include tone, themes, risks, or opportunities in presentation.

CARDS AND STARTER DECK:
- ""cards"": [] MUST be an empty array.
- ""starterDeck"": null MUST be null.
- Do NOT generate any cards or starter deck content.

STRUCTURE:
{{
  ""domains"": [
    {{
      ""domainId"": ""string"",
      ""domainName"": ""string"",
      ""summary"": ""string"",
      ""boundaries"": [""string""],
      ""tone"": ""string"",
      ""tags"": [""string""],
      ""opportunities"": [""string""],
      ""risks"": [""string""],
      ""driftWarnings"": [""string""],
      ""pressureTestSeeds"": [""string""],
      ""prismSeeds"": [""string""],
      ""timestamp"": ""string""
    }}
  ],
  ""concept"": {{
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
  }},
  ""cards"": [],
  ""starterDeck"": null,
  ""presentation"": {{
      ""title"": ""string"",
      ""subtitle"": ""string"",
      ""overview"": ""string"",
      ""pillars"": [""string""],
      ""recommendedNextSteps"": [""string""]
  }}
}}

Return ONLY the JSON object.
";
}
    }
}