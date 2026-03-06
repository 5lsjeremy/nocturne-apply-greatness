using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IConceptCore
    {
        string WorldConcept { get; }
        string? Fantasy { get; }
        string? CoreLoop { get; }
        IReadOnlyList<string> Verbs { get; }
        IReadOnlyList<string> Constraints { get; }
        string? Tone { get; }
        string? Pitch { get; }
    }
    
    public interface IConceptEvaluation
    {
        bool? IsClear { get; }
        IReadOnlyList<string> ClarityRecommendations { get; }
        IReadOnlyList<string> ClarityQuestions { get; }

        IReadOnlyList<string> PitchRecommendations { get; }
        IReadOnlyList<string> TagRecommendations { get; }

        string? Good { get; }
        string? Bad { get; }
        string? Ugly { get; }

        int? Momentum { get; }
        int? Inertia { get; }
        int? ClarityScore { get; }
        int? SpecificityScore { get; }
        int? NoveltyScore { get; }
        int? CoherenceScore { get; }

        IReadOnlyList<string> Risks { get; }
        IReadOnlyList<string> Recommendations { get; }
        IReadOnlyList<string> Questions { get; }

        string? TrajectoryParagraph { get; }

        bool IsFeasible { get; }
        string? FailureReason { get; }

        bool BlockersResolved { get; }
    }
    
    public interface IConceptExtraction
    {
        IOverlayTags? Tags { get; }

        IReadOnlyList<string> InferredTags { get; }
        IReadOnlyList<string> InferredSystems { get; }
        IReadOnlyList<string> InferredMechanics { get; }
        IReadOnlyList<string> InferredProgression { get; }
        IReadOnlyList<string> InferredAudience { get; }

        IReadOnlyList<IDomainSeed> DomainSeeds { get; }
        IReadOnlyList<ISparkSeed> SparkSeeds { get; }
    }
    
    public interface IConceptMetadata
    {
        string? RawResponse { get; }
        string? ParsedResponseJson { get; }
        string? PipelineInterpretation { get; }
        string? FallbackReason { get; }

        IReadOnlyCollection<ISurfaceLogEntry> Logs { get; }
    }
    public interface IDomainSeed
    {
        string Name { get; }
        string? Summary { get; }
        IReadOnlyList<string> Vectors { get; }
        IReadOnlyList<string> Stats { get; }
        IReadOnlyList<string> Behaviors { get; }
    }

    public interface ISparkSeed
    {
        string Prompt { get; }
        string SparkType { get; }
        IReadOnlyList<string> Tags { get; }
    }
}