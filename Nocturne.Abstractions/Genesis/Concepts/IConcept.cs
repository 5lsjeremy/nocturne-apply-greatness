using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;

namespace Nocturne.Abstractions.Genesis.Concepts;

public interface IConcept
{
    IWorldContext World { get; }

    ConceptCore Core { get; }
    ConceptClarity Clarity { get; }
    ConceptPitch Pitch { get; }
    ConceptTags Tags { get; }
    ConceptFeasibility Feasibility { get; }
    ConceptMetadata Metadata { get; }
}