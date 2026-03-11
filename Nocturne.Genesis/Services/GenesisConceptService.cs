using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;

namespace Nocturne.Genesis.Services
{
    internal sealed partial class GenesisConceptService
    {
        private sealed class ConceptFromDto : IConcept
        {
            private readonly LlmConceptResponse _dto;

            public ConceptFromDto(LlmConceptResponse dto)
            {
                _dto = dto;
                Core = new ConceptCore(dto);
                Evaluation = new ConceptEval(dto);
                Extraction = new ConceptExtract(dto);
                Metadata = new ConceptMeta();
            }

            public IWorldContext World => new EmptyWorldContext();
            public IConceptCore Core { get; }
            public IConceptEvaluation Evaluation { get; }
            public IConceptExtraction Extraction { get; }
            public IConceptMetadata Metadata { get; }

            // ------------------------------------------------------------
            // WORLD CONTEXT (dummy for harness)
            // ------------------------------------------------------------
            private sealed class EmptyWorldContext : IWorldContext
            {
                public IDomainState DomainState { get; } = new EmptyDomainState();
                public WorldFlags Flags => default!;
                public ISparkDeck SparkDeck => default!;
                public IPressureDeck PressureDeck => default!;
            }

            private sealed class EmptyDomainState : IDomainState
            {
                public IReadOnlyDictionary<string, IDomainValue> Domains { get; }
                    = new Dictionary<string, IDomainValue>();

                public void ApplyPressure(IDomainPressure pressure) { }
                public void ApplySpark(IDomainSpark spark) { }

                float IDomainState.WorldStability => WorldStability;

                public int WorldStability => 100;
                public bool IsCollapsing => false;
            }

            // ------------------------------------------------------------
            // CORE
            // ------------------------------------------------------------
            private sealed class ConceptCore : IConceptCore
            {
                private readonly LlmConceptResponse _dto;
                public ConceptCore(LlmConceptResponse dto) => _dto = dto;

                public string Summary
                {
                    get => _dto.Summary;
                    set { }
                }

                public string OneSentencePitch
                {
                    get => _dto.OneSentencePitch;
                    set { }
                }

                public string ThirtySecondPitch
                {
                    get => _dto.ThirtySecondPitch;
                    set { }
                }

                public string Tagline
                {
                    get => _dto.Tagline;
                    set { }
                }

                public string WorldConcept
                {
                    get => _dto.Summary ?? string.Empty;
                    set { }
                }

                public string? Fantasy
                {
                    get => _dto.CoreFantasy;
                    set { }
                }

                public string? CoreLoop
                {
                    get => null;
                    set { }
                }

                public IReadOnlyList<string> Verbs { get; } = Array.Empty<string>();
                public IReadOnlyList<string> Constraints { get; } = Array.Empty<string>();

                public string? Tone
                {
                    get => _dto.Tone;
                    set { }
                }

                public string? Pitch
                {
                    get => _dto.OneSentencePitch;
                    set { }
                }
            }

            // ------------------------------------------------------------
            // EVALUATION
            // ------------------------------------------------------------
            private sealed class ConceptEval : IConceptEvaluation
            {
                private readonly LlmConceptResponse _dto;
                public ConceptEval(LlmConceptResponse dto) => _dto = dto;

                public bool? IsClear
                {
                    get => _dto.ClarityScore >= 0.5;
                    set { }
                }

                public IReadOnlyList<string> ClarityRecommendations =>
                    string.IsNullOrWhiteSpace(_dto.ClarityNotes)
                        ? Array.Empty<string>()
                        : new[] { _dto.ClarityNotes };

                public IReadOnlyList<string> ClarityQuestions { get; } = Array.Empty<string>();
                public IReadOnlyList<string> PitchRecommendations { get; } = Array.Empty<string>();
                public IReadOnlyList<string> TagRecommendations { get; } = Array.Empty<string>();

                public string? Good
                {
                    get => null;
                    set { }
                }

                public string? Bad
                {
                    get => null;
                    set { }
                }

                public string? Ugly
                {
                    get => null;
                    set { }
                }

                public int? Momentum
                {
                    get => null;
                    set { }
                }

                public int? Inertia
                {
                    get => null;
                    set { }
                }

                public int? ClarityScore
                {
                    get => (int?)_dto.ClarityScore;
                    set { }
                }

                public int? SpecificityScore
                {
                    get => null;
                    set { }
                }

                public int? NoveltyScore
                {
                    get => null;
                    set { }
                }

                public int? CoherenceScore
                {
                    get => null;
                    set { }
                }

                public IReadOnlyList<string> Risks => _dto.ProductionRisks;
                public IReadOnlyList<string> Recommendations => _dto.RecommendedFocusAreas;
                public IReadOnlyList<string> Questions => Array.Empty<string>();

                public string? TrajectoryParagraph
                {
                    get => null;
                    set { }
                }

                public bool IsFeasible => _dto.ClarityScore >= 0.5;

                public string? FailureReason
                {
                    get => IsFeasible ? null : "Low clarity score";
                    set { }
                }

                public bool BlockersResolved
                {
                    get => true;
                    set { }
                }
            }

            // ------------------------------------------------------------
            // EXTRACTION
            // ------------------------------------------------------------
            private sealed class ConceptExtract : IConceptExtraction
            {
                private readonly LlmConceptResponse _dto;
                public ConceptExtract(LlmConceptResponse dto) => _dto = dto;

                public IReadOnlyList<string> Tags => _dto.ConceptTags;
                public IReadOnlyList<string> InferredTags => _dto.ConceptTags;
                public IReadOnlyList<string> InferredSystems => _dto.InferredSystems;
                public IReadOnlyList<string> InferredMechanics { get; } = Array.Empty<string>();
                public IReadOnlyList<string> InferredProgression { get; } = Array.Empty<string>();
                public IReadOnlyList<string> InferredAudience { get; } = Array.Empty<string>();
                public IReadOnlyList<IDomainSeed> DomainSeeds { get; } = Array.Empty<IDomainSeed>();
                public IReadOnlyList<ISparkSeed> SparkSeeds { get; } = Array.Empty<ISparkSeed>();

                IOverlayTags? IConceptExtraction.Tags
                {
                    get => new OverlayTagsCompat(_dto);
                }

                private sealed class OverlayTagsCompat : IOverlayTags
                {
                    private readonly LlmConceptResponse _dto;
                    public OverlayTagsCompat(LlmConceptResponse dto) => _dto = dto;

                    public string Tone
                    {
                        get => _dto.Tone ?? "neutral";
                        set { }
                    }

                    public string Density
                    {
                        get => "medium";
                        set { }
                    }

                    public string Style
                    {
                        get => "default";
                        set { }
                    }

                    public string WorldType
                    {
                        get => "generic";
                        set { }
                    }

                    public string Risk
                    {
                        get => "low";
                        set { }
                    }
                }
            }

            // ------------------------------------------------------------
            // METADATA
            // ------------------------------------------------------------
            private sealed class ConceptMeta : IConceptMetadata
            {
                public string RawResponse
                {
                    get => string.Empty;
                    set { }
                }

                public string ParsedResponseJson
                {
                    get => string.Empty;
                    set { }
                }

                public string PipelineInterpretation
                {
                    get => "Generated via world-package concept DTO";
                    set { }
                }

                public string? FallbackReason
                {
                    get => null;
                    set { }
                }

                public IReadOnlyCollection<ISurfaceLogEntry> Logs { get; }
                    = Array.Empty<ISurfaceLogEntry>();
            }
        }
    }
}