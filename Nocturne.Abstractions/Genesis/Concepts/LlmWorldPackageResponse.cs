using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public sealed class LlmWorldPackageResponse
    {
        public LlmDomainResponse Domain { get; init; } = default!;
        public LlmConceptResponse Concept { get; init; } = default!;
        public LlmCardResponse Card { get; init; } = default!;
        public LlmStarterDeckResponse StarterDeck { get; init; } = default!;
        public LlmPresentationResponse Presentation { get; init; } = default!;
    }
}