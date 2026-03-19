using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensVersioningService
    {
        Task<ILensVersionInfo> RecordCycleAsync(
            ILensContext context,
            ILensResult result,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default);

        Task<ILensVersionInfo> GetVersionInfoAsync(
            string lensCycleId,
            CancellationToken cancellationToken = default);

        Task<ILensResult> LoadResultAsync(
            string lensCycleId,
            CancellationToken cancellationToken = default);

        Task<ILensContext> LoadContextAsync(
            string lensCycleId,
            CancellationToken cancellationToken = default);

        Task<ILensDiff> DiffAsync(
            string fromCycleId,
            string toCycleId,
            CancellationToken cancellationToken = default);
        
        Task<ILensRollbackResult> RollbackAsync(
            string lensCycleId,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default);

    }
}