using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis.Concepts
{
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
}