using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Genesis.Utilities;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Assemblers
{
    public sealed class ConceptAssembler
    {
        public ConceptArtifactsDTO Assemble(
            LlmConceptResponse llm,
            string conceptId,
            ISurfaceLogger logger)
        {
            // Load templates
            var coreTemplate        = TemplateLoader.LoadTemplate<ConceptCore>("Concepts/concept.json");
            var clarityTemplate     = TemplateLoader.LoadTemplate<ConceptClarity>("Concepts/clarity.json");
            var pitchTemplate       = TemplateLoader.LoadTemplate<ConceptPitch>("Concepts/pitch.json");
            var tagsTemplate        = TemplateLoader.LoadTemplate<ConceptTags>("Concepts/tags.json");
            var feasibilityTemplate = TemplateLoader.LoadTemplate<ConceptFeasibility>("Concepts/feasibility.json");
            var logsTemplate        = TemplateLoader.LoadTemplate<ConceptLogs>("Concepts/logs.json");

            // Generate slug
            var slug = ArtifactIdentity.Slugify(llm.WorldName ?? "concept");

            // Core block
            var core = coreTemplate with
            {
                WorldName         = llm.WorldName,
                Summary           = llm.Summary,
                Themes            = llm.Themes.ToList(),
                CoreFantasy       = llm.CoreFantasy,
                Tone              = llm.Tone,
                Genre             = llm.Genre,
                Setting           = llm.Setting,
                PlayerFantasy     = llm.PlayerFantasy,
                CreativeNorthStar = llm.CreativeNorthStar,
                SeedId            = conceptId,
                Timestamp         = DateTime.UtcNow
            };

            // Clarity block
            var clarity = clarityTemplate with
            {
                ClarityScore = llm.ClarityScore,
                Good         = llm.Good,
                Bad          = llm.Bad,
                Ugly         = llm.Ugly,
                Notes        = llm.ClarityNotes,
                Timestamp    = DateTime.UtcNow
            };

            // Pitch block
            var pitch = pitchTemplate with
            {
                Tagline            = llm.Tagline,
                OneSentencePitch   = llm.OneSentencePitch,
                ThirtySecondPitch  = llm.ThirtySecondPitch,
                MarketPosition     = llm.MarketPosition,
                EmotionalHook      = llm.EmotionalHook,
                PlayerPromise      = llm.PlayerPromise,
                Timestamp          = DateTime.UtcNow
            };

            // Tags block
            var tags = tagsTemplate with
            {
                ConceptTagsList = llm.ConceptTags.ToList(),
                MechanicTags    = llm.MechanicTags.ToList(),
                MoodTags        = llm.MoodTags.ToList(),
                ThemeTags       = llm.ThemeTags.ToList(),
                SettingTags     = llm.SettingTags.ToList(),
                InferredDomains = llm.InferredDomains.ToList(),
                InferredSystems = llm.InferredSystems.ToList(),
                Timestamp       = DateTime.UtcNow
            };

            // Feasibility block
            var feasibility = feasibilityTemplate with
            {
                CreativePotential     = llm.CreativePotential,
                ProductionRisks       = llm.ProductionRisks.ToList(),
                Opportunities         = llm.Opportunities.ToList(),
                Pitfalls              = llm.Pitfalls.ToList(),
                AlignmentWithGenre    = llm.AlignmentWithGenre,
                ExpectedComplexity    = llm.ExpectedComplexity,
                RecommendedFocusAreas = llm.RecommendedFocusAreas.ToList(),
                Timestamp             = DateTime.UtcNow
            };

            // Logs block
            var logs = logsTemplate with
            {
                Entries = logger.Entries
                    .Select(e => new ConceptLogEntry
                    {
                        Timestamp = e.Timestamp,
                        Message   = e.Message,
                        Source    = e.Source,
                        SeedId    = conceptId,
                        Version   = "1"
                    })
                    .ToList()
            };

            return new ConceptArtifactsDTO(
                conceptId,
                slug,
                core,
                clarity,
                pitch,
                tags,
                feasibility,
                logs
            );
        }
    }
}