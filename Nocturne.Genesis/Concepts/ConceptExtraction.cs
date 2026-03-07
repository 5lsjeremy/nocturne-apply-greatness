using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;

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