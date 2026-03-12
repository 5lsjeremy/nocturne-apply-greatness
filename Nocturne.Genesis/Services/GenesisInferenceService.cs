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

        // NEW unified method
        public Task<LlmWorldPackageResponse> GenerateWorldPackageAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default)
        {
            var effectiveTags = tags ?? context.OverlayTags;
            return _llm.GenerateWorldPackageAsync(context, effectiveTags, ct);
        }
    }
}