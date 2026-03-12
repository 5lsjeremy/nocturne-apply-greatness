using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis;

public interface IGenesisInferenceService
{
    Task<LlmWorldPackageResponse> GenerateWorldPackageAsync(
        IGenesisContext context,
        IOverlayTags? tags = null,
        CancellationToken ct = default);
}