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

Return ONLY valid JSON with fields:
- worldName: string
- summary: string
- themes: string[]
- coreFantasy: string
- tone: string
- genre: string
- setting: string
- playerFantasy: string
- creativeNorthStar: string
- seedId: string
- clarityScore: number
- good: string[]
- bad: string[]
- ugly: string[]
- clarityNotes: string[]
- tagline: string
- oneSentencePitch: string
- thirtySecondPitch: string
- marketPosition: string
- emotionalHook: string
- playerPromise: string
- conceptTags: string[]
- mechanicTags: string[]
- moodTags: string[]
- themeTags: string[]
- settingTags: string[]
- inferredDomains: string[]
- inferredSystems: string[]
- creativePotential: string
- productionRisks: string[]
- opportunities: string[]
- pitfalls: string[]
- alignmentWithGenre: string
- expectedComplexity: string
- recommendedFocusAreas: string[]
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