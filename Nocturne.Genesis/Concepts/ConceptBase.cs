using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Genesis.Concepts.Nocturne.Genesis.Concepts;
using Nocturne.Genesis.Concepts.Nocturne.Genesis.Concepts.Nocturne.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class ConceptBase : IConcept
    {
        public ConceptCore Core { get; set; } = new();
        public ConceptEvaluation Evaluation { get; set; } = new();
        public ConceptExtraction Extraction { get; set; } = new();
        public ConceptMetadata Metadata { get; set; } = new();

        IConceptCore IConcept.Core => Core;
        IConceptEvaluation IConcept.Evaluation => Evaluation;
        IConceptExtraction IConcept.Extraction => Extraction;
        IConceptMetadata IConcept.Metadata => Metadata;
    }
    
    namespace Nocturne.Genesis.Concepts
    {
        internal sealed class ConceptCore : IConceptCore
        {
            public string WorldConcept { get; set; } = "";
            public string? Fantasy { get; set; }
            public string? CoreLoop { get; set; }
            public IReadOnlyList<string> Verbs { get; set; } = Array.Empty<string>();
            public IReadOnlyList<string> Constraints { get; set; } = Array.Empty<string>();
            public string? Tone { get; set; }
            public string? Pitch { get; set; }
        }
        
        namespace Nocturne.Genesis.Concepts
        {
            internal sealed class ConceptEvaluation : IConceptEvaluation
            {
                public bool? IsClear { get; set; }
                public IReadOnlyList<string> ClarityRecommendations { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> ClarityQuestions { get; set; } = Array.Empty<string>();

                public IReadOnlyList<string> PitchRecommendations { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> TagRecommendations { get; set; } = Array.Empty<string>();

                public string? Good { get; set; }
                public string? Bad { get; set; }
                public string? Ugly { get; set; }

                public int? Momentum { get; set; }
                public int? Inertia { get; set; }
                public int? ClarityScore { get; set; }
                public int? SpecificityScore { get; set; }
                public int? NoveltyScore { get; set; }
                public int? CoherenceScore { get; set; }

                public IReadOnlyList<string> Risks { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> Recommendations { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> Questions { get; set; } = Array.Empty<string>();

                public string? TrajectoryParagraph { get; set; }

                public bool IsFeasible { get; set; }
                public string? FailureReason { get; set; }

                public bool BlockersResolved { get; set; }
            }
        }
        
        namespace Nocturne.Genesis.Concepts
        {
            internal sealed class ConceptExtraction : IConceptExtraction
            {
                public IOverlayTags? Tags { get; set; }

                public IReadOnlyList<string> InferredTags { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> InferredSystems { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> InferredMechanics { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> InferredProgression { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> InferredAudience { get; set; } = Array.Empty<string>();

                public IReadOnlyList<IDomainSeed> DomainSeeds { get; set; } = Array.Empty<IDomainSeed>();
                public IReadOnlyList<ISparkSeed> SparkSeeds { get; set; } = Array.Empty<ISparkSeed>();
            }
        }
        
        namespace Nocturne.Genesis.Concepts
        {
            internal sealed class ConceptMetadata : IConceptMetadata
            {
                private readonly List<ISurfaceLogEntry> _logs = new();

                public IReadOnlyCollection<ISurfaceLogEntry> Logs => _logs;

                public string? RawResponse { get; set; }
                public string? ParsedResponseJson { get; set; }
                public string? PipelineInterpretation { get; set; }
                public string? FallbackReason { get; set; }

                // Internal helper for Genesis to append logs
                internal void AddLog(ISurfaceLogEntry entry) => _logs.Add(entry);
            }

        }
        
        namespace Nocturne.Genesis.Concepts
        {
            internal sealed class DomainSeed : IDomainSeed
            {
                public string Name { get; set; } = "";
                public string? Summary { get; set; }
                public IReadOnlyList<string> Vectors { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> Stats { get; set; } = Array.Empty<string>();
                public IReadOnlyList<string> Behaviors { get; set; } = Array.Empty<string>();
            }

            internal sealed class SparkSeed : ISparkSeed
            {
                public string Prompt { get; set; } = "";
                public string SparkType { get; set; } = "mechanical";
                public IReadOnlyList<string> Tags { get; set; } = Array.Empty<string>();
            }
        }
    }
}