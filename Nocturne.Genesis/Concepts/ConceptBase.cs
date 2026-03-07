using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class ConceptBase : IConcept
    {
        public IWorldContext World { get; protected set; }

        public ConceptCore Core { get; set; } = new();
        public ConceptEvaluation Evaluation { get; set; } = new();
        public ConceptExtraction Extraction { get; set; } = new();
        public ConceptMetadata Metadata { get; set; } = new();

        IConceptCore IConcept.Core => Core;
        IConceptEvaluation IConcept.Evaluation => Evaluation;
        IConceptExtraction IConcept.Extraction => Extraction;
        IConceptMetadata IConcept.Metadata => Metadata;
    }
}