using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Genesis.Concepts;

internal sealed class ConceptFromDto : IConcept
{
    private readonly LlmConceptResponse _dto;

    public ConceptFromDto(LlmConceptResponse dto)
    {
        _dto = dto;
    }

    public IWorldContext World =>
        new WorldContext(
            domainState: new EmptyDomainState(),
            sparkDeck: new EmptySparkDeck(),
            pressureDeck: new EmptyPressureDeck(),
            flags: WorldFlags.None
        );

    public ConceptCore Core => new ConceptCore
    {
        WorldName = _dto.WorldName,
        Summary = _dto.Summary,
        Themes = _dto.Themes,
        CoreFantasy = _dto.CoreFantasy,
        Tone = _dto.Tone,
        Genre = _dto.Genre,
        Setting = _dto.Setting,
        PlayerFantasy = _dto.PlayerFantasy,
        CreativeNorthStar = _dto.CreativeNorthStar,
        SeedId = _dto.SeedId,
        Timestamp = DateTime.UtcNow
    };


    public ConceptClarity Clarity => new ConceptClarity
    {
        ClarityScore = _dto.ClarityScore,
        Good = _dto.Good,
        Bad = _dto.Bad,
        Ugly = _dto.Ugly,
        Notes = _dto.ClarityNotes,   // IMPORTANT: DTO property is Notes, LLM field is clarityNotes
        Timestamp = DateTime.UtcNow
    };


    public ConceptPitch Pitch => new ConceptPitch
    {
        Tagline = _dto.Tagline,
        OneSentencePitch = _dto.OneSentencePitch,
        ThirtySecondPitch = _dto.ThirtySecondPitch,
        MarketPosition = _dto.MarketPosition,
        EmotionalHook = _dto.EmotionalHook,
        PlayerPromise = _dto.PlayerPromise,
        Timestamp = DateTime.UtcNow
    };

    public ConceptTags Tags => new ConceptTags
    {
        ConceptTagsList = _dto.ConceptTags,
        MechanicTags = _dto.MechanicTags,
        MoodTags = _dto.MoodTags,
        ThemeTags = _dto.ThemeTags,
        SettingTags = _dto.SettingTags,
        InferredDomains = _dto.InferredDomains,
        InferredSystems = _dto.InferredSystems,
        Timestamp = DateTime.UtcNow
    };

    public ConceptFeasibility Feasibility => new ConceptFeasibility
    {
        CreativePotential = _dto.CreativePotential,
        ProductionRisks = _dto.ProductionRisks,
        Opportunities = _dto.Opportunities,
        Pitfalls = _dto.Pitfalls,
        AlignmentWithGenre = _dto.AlignmentWithGenre,
        ExpectedComplexity = _dto.ExpectedComplexity,
        RecommendedFocusAreas = _dto.RecommendedFocusAreas,
        Timestamp = DateTime.UtcNow
    };

    public ConceptMetadata Metadata => new ConceptMetadata(
        RawResponse: null,
        ParsedResponseJson: null,
        PipelineInterpretation: "Generated from LlmConceptResponse",
        FallbackReason: null,
        Logs: Array.Empty<ISurfaceLogEntry>()
    );

    // ------------------------------------------------------------
    // NESTED EMPTY IMPLEMENTATIONS
    // ------------------------------------------------------------
    private sealed class EmptyDomainState : IDomainState
    {
        public IReadOnlyDictionary<string, IDomainValue> Domains { get; }
            = new Dictionary<string, IDomainValue>();

        public void ApplyPressure(IDomainPressure pressure) { }
        public void ApplySpark(IDomainSpark spark) { }

        public float WorldStability => 100;
        public bool IsCollapsing => false;
    }

    private sealed class EmptySparkDeck : ISparkDeck
    {
        public IReadOnlyList<IDomainSpark> DrawPile { get; } = Array.Empty<IDomainSpark>();
        public IReadOnlyList<IDomainSpark> DiscardPile { get; } = Array.Empty<IDomainSpark>();
        public bool CanDraw => false;

        public IDomainSpark Draw() => throw new NotImplementedException();
        public void Discard(IDomainSpark spark) => throw new NotImplementedException();
        public void Reshuffle() => throw new NotImplementedException();
    }

    private sealed class EmptyPressureDeck : IPressureDeck
    {
        public IReadOnlyList<IDomainPressure> DrawPile { get; } = Array.Empty<IDomainPressure>();
        public IReadOnlyList<IDomainPressure> DiscardPile { get; } = Array.Empty<IDomainPressure>();
        public bool CanDraw => false;

        public IDomainPressure Draw() => throw new NotImplementedException();
        public void Discard(IDomainPressure pressure) => throw new NotImplementedException();
        public void Reshuffle() => throw new NotImplementedException();
    }
}