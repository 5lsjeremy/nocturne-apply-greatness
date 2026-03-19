//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Surface;
using Nocturne.Lens.Abstractions.Models;

namespace Nocturne.Lens.Services
{
    internal sealed class LensVersioningService : ILensVersioningService
    {
        private readonly Dictionary<string, ILensContext> _contexts = new();
        private readonly Dictionary<string, ILensResult> _results = new();
        private readonly Dictionary<string, ILensVersionInfo> _versions = new();

        public Task<ILensVersionInfo> RecordCycleAsync(
            ILensContext context,
            ILensResult result,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default)
        {
            var versionInfo = new LensVersionInfo
            {
                LensCycleId = Guid.NewGuid().ToString("N"),
                EngineVersion = "1.0.0",
                RuleSetVersion = "1.0.0",
                PassPipelineVersion = "1.0.0",
                Timestamp = DateTimeOffset.UtcNow
            };

            logger.Info($"Recording Lens cycle {versionInfo.LensCycleId}");

            // TODO: Persist to durable storage
            _contexts[versionInfo.LensCycleId] = context;
            _results[versionInfo.LensCycleId] = result;
            _versions[versionInfo.LensCycleId] = versionInfo;

            return Task.FromResult<ILensVersionInfo>(versionInfo);
        }

        public Task<ILensVersionInfo> GetVersionInfoAsync(
            string lensCycleId,
            CancellationToken cancellationToken = default)
        {
            _versions.TryGetValue(lensCycleId, out var info);

            return Task.FromResult<ILensVersionInfo>(info ?? new LensVersionInfo
            {
                LensCycleId = lensCycleId,
                EngineVersion = "unknown",
                RuleSetVersion = "unknown",
                PassPipelineVersion = "unknown",
                Timestamp = DateTimeOffset.MinValue
            });
        }

        public Task<ILensResult> LoadResultAsync(
            string lensCycleId,
            CancellationToken cancellationToken = default)
        {
            _results.TryGetValue(lensCycleId, out var result);
            return Task.FromResult<ILensResult>(result ?? new LensResult());
        }

        public Task<ILensContext> LoadContextAsync(
            string lensCycleId,
            CancellationToken cancellationToken = default)
        {
            if (!_contexts.TryGetValue(lensCycleId, out var context))
                throw new InvalidOperationException($"No LensContext found for cycle {lensCycleId}");

            return Task.FromResult(context);
        }

        public Task<ILensDiff> DiffAsync(
            string fromCycleId,
            string toCycleId,
            CancellationToken cancellationToken = default)
        {
            // Kept for backward compatibility if you still want versioning to expose diff.
            // Prefer ILensDiffService for richer behavior.
            return Task.FromResult<ILensDiff>(new LensDiff());
        }

        public Task<ILensRollbackResult> RollbackAsync(
            string lensCycleId,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default)
        {
            logger.Info($"Rolling back Lens cycle {lensCycleId}");

            // TODO: If world state is ever persisted per cycle, restore it here.

            var context = _contexts.TryGetValue(lensCycleId, out var ctx)
                ? ctx
                : throw new InvalidOperationException($"No context found for cycle {lensCycleId}");

            var result = _results.TryGetValue(lensCycleId, out var res)
                ? res
                : new LensResult();

            var version = _versions.TryGetValue(lensCycleId, out var ver)
                ? ver
                : new LensVersionInfo();

            return Task.FromResult<ILensRollbackResult>(new LensRollbackResult
            {
                RestoredContext = context,
                RestoredResult = result,
                VersionInfo = version
            });
        }
    }
}