using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;

namespace Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO
{
    public class UnifiedWorldPackageDto
    {
        public List<DomainDefinition> Domains { get; set; } = new();
        public ConceptArtifactsDTO Concept { get; set; } = default!;

        // Genesis always returns an empty array
        public List<CardDefinition> Cards { get; set; } = new();

        // Genesis always returns null
        public StarterDeckDefinition? StarterDeck { get; set; } = null;

        public PresentationDefinition Presentation { get; set; } = new();
    }
}