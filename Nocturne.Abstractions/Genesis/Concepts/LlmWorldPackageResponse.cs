using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public sealed class LlmWorldPackageResponse
    {
        // Genesis now returns an array of domains
        public LlmDomainResponse[] Domains { get; init; } = Array.Empty<LlmDomainResponse>();

        // Concept is still a single object
        public LlmConceptResponse Concept { get; init; } = default!;

        // Cards must always be an empty array
        public LlmCardResponse[] Cards { get; init; } = Array.Empty<LlmCardResponse>();

        // StarterDeck must always be null
        public LlmStarterDeckResponse? StarterDeck { get; init; } = null;

        // Presentation is still a single object
        public LlmPresentationResponse Presentation { get; init; } = default!;
    }
}