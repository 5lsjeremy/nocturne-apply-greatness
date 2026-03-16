using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Genesis.Utilities;

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
        var slug = ArtifactIdentity.Slugify(llm.Core.WorldName ?? "concept");

        // -------------------------
        // Core block
        // -------------------------
        var core = coreTemplate with
        {
            WorldName         = llm.Core.WorldName,
            Summary           = llm.Core.Summary,
            Themes            = llm.Core.Themes.ToList(),
            CoreFantasy       = llm.Core.CoreFantasy,
            Tone              = llm.Core.Tone,
            Genre             = llm.Core.Genre,
            Setting           = llm.Core.Setting,
            PlayerFantasy     = llm.Core.PlayerFantasy,
            CreativeNorthStar = llm.Core.CreativeNorthStar,
            SeedId            = conceptId,
            Timestamp         = DateTime.UtcNow
        };

        // -------------------------
        // Clarity block
        // -------------------------
        var clarity = clarityTemplate with
        {
            ClarityScore = llm.Clarity.ClarityScore,
            Good         = llm.Clarity.Good,
            Bad          = llm.Clarity.Bad,
            Ugly         = llm.Clarity.Ugly,
            Notes        = llm.Clarity.Notes,
            Timestamp    = DateTime.UtcNow
        };

        // -------------------------
        // Pitch block
        // -------------------------
        var pitch = pitchTemplate with
        {
            Tagline           = llm.Pitch.Tagline,
            OneSentencePitch  = llm.Pitch.OneSentencePitch,
            ThirtySecondPitch = llm.Pitch.ThirtySecondPitch,
            MarketPosition    = llm.Pitch.MarketPosition,
            EmotionalHook     = llm.Pitch.EmotionalHook,
            PlayerPromise     = llm.Pitch.PlayerPromise,
            Timestamp         = DateTime.UtcNow
        };

        // -------------------------
        // Tags block
        // -------------------------
        var tags = tagsTemplate with
        {
            ConceptTagsList = llm.Tags.ConceptTagsList.ToList(),
            MechanicTags    = llm.Tags.MechanicTags.ToList(),
            MoodTags        = llm.Tags.MoodTags.ToList(),
            ThemeTags       = llm.Tags.ThemeTags.ToList(),
            SettingTags     = llm.Tags.SettingTags.ToList(),
            InferredDomains = llm.Tags.InferredDomains.ToList(),
            InferredSystems = llm.Tags.InferredSystems.ToList(),
            Timestamp       = DateTime.UtcNow
        };

        // -------------------------
        // Feasibility block
        // -------------------------
        var feasibility = feasibilityTemplate with
        {
            CreativePotential     = llm.Feasibility.CreativePotential,
            ProductionRisks       = llm.Feasibility.ProductionRisks.ToList(),
            Opportunities         = llm.Feasibility.Opportunities.ToList(),
            Pitfalls              = llm.Feasibility.Pitfalls.ToList(),
            AlignmentWithGenre    = llm.Feasibility.AlignmentWithGenre,
            ExpectedComplexity    = llm.Feasibility.ExpectedComplexity,
            RecommendedFocusAreas = llm.Feasibility.RecommendedFocusAreas.ToList(),
            Timestamp             = DateTime.UtcNow
        };

        // -------------------------
        // Logs block
        // -------------------------
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