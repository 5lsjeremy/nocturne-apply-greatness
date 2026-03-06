using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IConcept
    {
        public IWorldContext World { get; }
        IConceptCore Core { get; }
        IConceptEvaluation Evaluation { get; }
        IConceptExtraction Extraction { get; }
        IConceptMetadata Metadata { get; }
    }
}