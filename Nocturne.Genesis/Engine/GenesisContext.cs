using System.Text.Json;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;
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
        public IConcept Concept { get; }

        public GenesisContext(
            ISurfaceArtifact seed,
            IConcept concept,
            IList<ICard> cards,
            IDictionary<string, object?> answers,
            IOverlayTags? overlayTags)
        {
            Seed = seed;
            Concept = concept;
            Cards = cards;
            Answers = answers;
            OverlayTags = overlayTags;
        }

        private static string Serialize(object? obj)
            => JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        //
        // DOMAIN PROMPT
        //
        public string BuildDomainPrompt(IOverlayTags? tags = null)
        {
            var overlay = tags ?? OverlayTags ?? new OverlayTags("neutral", "medium", "literal", "generic", "medium");

            return $@"
You are a world-domain architect. Generate a JSON object describing a single
coherent domain inside a larger world.

SEED ARTIFACT:
{Seed.WorldConcept}

EVALUATED CONCEPT:
{Concept.Core}

OVERLAY TAGS:
{Serialize(overlay)}

Respond ONLY with valid JSON.
Use ONLY standard ASCII characters.
Use ONLY standard ASCII double quotes ("" "") for all strings.
Do NOT use smart quotes, curly quotes, angled quotes, em-dashes, en-dashes,
accented characters, or any non-ASCII punctuation.

Return ONLY valid JSON with fields:
- domainName: string
- summary: string
- boundaries: string[]
- tone: string
- tags: string[]
- opportunities: string[]
- risks: string[]
- driftWarnings: string[]
- pressureTestSeeds: string[]
- prismSeeds: string[]
- timestamp: string (ISO 8601)
";
        }
        //
        // CONCEPT PROMPT
        //
        public string BuildConceptPrompt(IOverlayTags? tags = null)
{
    var overlay = tags ?? OverlayTags ?? new OverlayTags("neutral", "medium", "literal", "generic", "medium");

    return $@"
You are a world-concept generator. Produce a JSON object describing the core
creative concept for a new world.

SEED ARTIFACT:
{Seed.WorldConcept}

OVERLAY TAGS:
{Serialize(overlay)}

Respond ONLY with valid JSON.
Use ONLY standard ASCII characters.
Use ONLY standard ASCII double quotes ("" "") for all strings.
Do NOT use smart quotes, curly quotes, angled quotes, em-dashes, en-dashes,
accented characters, or any non-ASCII punctuation.

IMPORTANT TYPE RULES:
- All fields shown as string MUST be a JSON string, NOT an array.
- Do NOT return arrays for: worldName, summary, coreFantasy, tone, genre,
  setting, playerFantasy, creativeNorthStar, tagline, oneSentencePitch,
  thirtySecondPitch, marketPosition, emotionalHook, playerPromise,
  creativePotential, alignmentWithGenre, expectedComplexity, notes.
- Arrays are ONLY allowed where explicitly shown as [].

Return ONLY valid JSON matching this schema:

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

        //
        // CARD PROMPT
        //
        public string BuildCardPrompt(IOverlayTags? tags = null)
        {
            var overlay = tags ?? OverlayTags ?? new OverlayTags("neutral", "medium", "literal", "generic", "medium");

            return $@"
You are a card generator for a worldbuilding system. Produce a JSON object
describing a single card.

SEED ARTIFACT:
{Seed.WorldConcept}

CONCEPT:
{Concept.Core}

EXISTING CARDS:
{Serialize(Cards)}

OVERLAY TAGS:
{Serialize(overlay)}

Return ONLY valid JSON with fields:
- title: string
- summary: string
- mechanics: string[]
- narrative: string
- tags: string[]
";
        }

        //
        // STARTER DECK PROMPT
        //
        public string BuildStarterDeckPrompt(IOverlayTags? tags = null)
        {
            var overlay = tags ?? OverlayTags ?? new OverlayTags("neutral", "medium", "literal", "generic", "medium");

            return $@"
You are a starter-deck architect. Produce a JSON object describing a starter
deck for this world.

CONCEPT:
{Concept.Core}

EXISTING CARDS:
{Serialize(Cards)}

OVERLAY TAGS:
{Serialize(overlay)}

Return ONLY valid JSON with fields:
- deckName: string
- summary: string
- recommendedCards: string[]
- onboardingNotes: string[]
- risks: string[]
- opportunities: string[]
";
        }

        //
        // PRESENTATION PROMPT
        //
        public string BuildPresentationPrompt(IOverlayTags? tags = null)
        {
            var overlay = tags ?? OverlayTags ?? new OverlayTags("neutral", "medium", "literal", "generic", "medium");

            return $@"
You are a world-presentation generator. Produce a JSON object describing a
presentation-ready summary of the world.

CONCEPT:
{Concept.Core}

CARDS:
{Serialize(Cards)}

OVERLAY TAGS:
{Serialize(overlay)}

Return ONLY valid JSON with fields:
- title: string
- subtitle: string
- overview: string
- pillars: string[]
- tone: string
- themes: string[]
- risks: string[]
- opportunities: string[]
- recommendedNextSteps: string[]
";
        }
    }
}