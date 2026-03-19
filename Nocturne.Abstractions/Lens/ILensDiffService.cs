//v.01 updated 26.03.18

using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensDiffService
    {
        Task<ILensDiff> DiffAsync(
            string fromCycleId,
            string toCycleId,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default);
    }
}