using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IGenesisWorldLlmAdapter
    {
        Task<LlmWorldPackageResponse> GenerateWorldPackageAsync(
            IGenesisContext context,
            IOverlayTags? tags = null,
            CancellationToken ct = default);
    }
}