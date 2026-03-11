using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IGenesisWorldLlmAdapter
    {
        Task<LlmDomainResponse> GenerateDomainAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default);

        Task<LlmConceptResponse> GenerateConceptAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default);

        Task<LlmCardResponse> GenerateCardAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default);

        Task<LlmStarterDeckResponse> GenerateStarterDeckAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default);

        Task<LlmPresentationResponse> GeneratePresentationAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default);

        Task<string> GenerateRawAsync(string prompt, CancellationToken ct = default);
    }
}