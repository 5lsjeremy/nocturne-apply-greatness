using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;

namespace Nocturne.Genesis.Services;

internal sealed class ConceptFromDto : IConcept
{
    private readonly LlmConceptResponse _dto;

    public ConceptFromDto(LlmConceptResponse dto)
    {
        _dto = dto ?? new LlmConceptResponse();
    }

    public ConceptCore Core => new ConceptCore
    {
        WorldName         = _dto.Core.WorldName,
        Summary           = _dto.Core.Summary,
        Themes            = _dto.Core.Themes,
        CoreFantasy       = _dto.Core.CoreFantasy,
        Tone              = _dto.Core.Tone,
        Genre             = _dto.Core.Genre,
        Setting           = _dto.Core.Setting,
        PlayerFantasy     = _dto.Core.PlayerFantasy,
        CreativeNorthStar = _dto.Core.CreativeNorthStar,
        SeedId            = _dto.SeedId,
        Timestamp         = DateTime.UtcNow
    };

    public ConceptClarity Clarity => new ConceptClarity
    {
        ClarityScore = _dto.Clarity.ClarityScore,
        Good         = _dto.Clarity.Good,
        Bad          = _dto.Clarity.Bad,
        Ugly         = _dto.Clarity.Ugly,
        Notes        = _dto.Clarity.Notes,
        Timestamp    = DateTime.UtcNow
    };

    public ConceptPitch Pitch => new ConceptPitch
    {
        Tagline           = _dto.Pitch.Tagline,
        OneSentencePitch  = _dto.Pitch.OneSentencePitch,
        ThirtySecondPitch = _dto.Pitch.ThirtySecondPitch,
        MarketPosition    = _dto.Pitch.MarketPosition,
        EmotionalHook     = _dto.Pitch.EmotionalHook,
        PlayerPromise     = _dto.Pitch.PlayerPromise,
        Timestamp         = DateTime.UtcNow
    };

    public ConceptTags Tags => new ConceptTags
    {
        ConceptTagsList = _dto.Tags.ConceptTagsList,
        MechanicTags    = _dto.Tags.MechanicTags,
        MoodTags        = _dto.Tags.MoodTags,
        ThemeTags       = _dto.Tags.ThemeTags,
        SettingTags     = _dto.Tags.SettingTags,
        InferredDomains = _dto.Tags.InferredDomains,
        InferredSystems = _dto.Tags.InferredSystems,
        Timestamp       = DateTime.UtcNow
    };

    public ConceptFeasibility Feasibility => new ConceptFeasibility
    {
        CreativePotential     = _dto.Feasibility.CreativePotential,
        ProductionRisks       = _dto.Feasibility.ProductionRisks,
        Opportunities         = _dto.Feasibility.Opportunities,
        Pitfalls              = _dto.Feasibility.Pitfalls,
        AlignmentWithGenre    = _dto.Feasibility.AlignmentWithGenre,
        ExpectedComplexity    = _dto.Feasibility.ExpectedComplexity,
        RecommendedFocusAreas = _dto.Feasibility.RecommendedFocusAreas,
        Timestamp             = DateTime.UtcNow
    };

    public ConceptMetadata Metadata { get; }
    public IWorldContext World { get; }
}