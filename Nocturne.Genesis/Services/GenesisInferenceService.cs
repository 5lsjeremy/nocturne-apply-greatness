using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;

namespace Nocturne.Genesis.Services
{
    internal sealed class GenesisInferenceService : IGenesisInferenceService
    {
        private readonly IGenesisWorldLlmAdapter _llm;

        public GenesisInferenceService(IGenesisWorldLlmAdapter llm)
        {
            _llm = llm;
        }

        public Task<LlmDomainResponse> GenerateDomainAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default)
        {
            var effectiveTags = tags ?? context.OverlayTags;
            return _llm.GenerateDomainAsync(context, effectiveTags, ct);
        }

        public Task<LlmConceptResponse> GenerateConceptAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default)
        {
            var effectiveTags = tags ?? context.OverlayTags;
            return _llm.GenerateConceptAsync(context, effectiveTags, ct);
        }

        public Task<LlmCardResponse> GenerateCardAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default)
        {
            var effectiveTags = tags ?? context.OverlayTags;
            return _llm.GenerateCardAsync(context, effectiveTags, ct);
        }

        public Task<LlmStarterDeckResponse> GenerateStarterDeckAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default)
        {
            var effectiveTags = tags ?? context.OverlayTags;
            return _llm.GenerateStarterDeckAsync(context, effectiveTags, ct);
        }

        public Task<LlmPresentationResponse> GeneratePresentationAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default)
        {
            var effectiveTags = tags ?? context.OverlayTags;
            return _llm.GeneratePresentationAsync(context, effectiveTags, ct);
        }
    }
}