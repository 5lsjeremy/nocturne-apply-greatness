using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.WorldPackageSchema.SurfaceDTO;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisBuilder
    {
        Task<SurfaceDTO> BuildWorldAsync(
            string rootPath,
            ISurfaceArtifact seed,
            IGenesisContext context,
            string inferenceRunId,
            IOverlayTags? tags,
            LlmWorldPackageResponse world,
            CancellationToken ct = default
        );
    }
}