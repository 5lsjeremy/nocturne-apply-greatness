//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Surface;
using Nocturne.Lens.Abstractions.Models;

namespace Nocturne.Lens.Services
{
    internal sealed class LensDiffService : ILensDiffService
    {
        private readonly ILensVersioningService _versioning;

        public LensDiffService(ILensVersioningService versioning)
        {
            _versioning = versioning;
        }

        public async Task<ILensDiff> DiffAsync(
            string fromCycleId,
            string toCycleId,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default)
        {
            logger.Info($"Computing Lens diff: {fromCycleId} → {toCycleId}");

            var fromContext = await _versioning.LoadContextAsync(fromCycleId, cancellationToken);
            var toContext = await _versioning.LoadContextAsync(toCycleId, cancellationToken);

            var fromResult = await _versioning.LoadResultAsync(fromCycleId, cancellationToken);
            var toResult = await _versioning.LoadResultAsync(toCycleId, cancellationToken);

            // TODO: Implement real diff logic
            // - Compare:
            //     * fromContext.Index.Domains vs toContext.Index.Domains
            //     * overlay tags (tone/style/density/worldType/risk)
            //     * diagnoses (by Id / TargetId)
            //     * questions (by Id / Prompt)
            //     * planned updates (by Id / TargetId / MutationType)
            // - Populate Added / Removed / Modified with meaningful identifiers

            return new LensDiff
            {
                Added = Array.Empty<string>(),
                Removed = Array.Empty<string>(),
                Modified = Array.Empty<string>()
            };
        }
    }
}