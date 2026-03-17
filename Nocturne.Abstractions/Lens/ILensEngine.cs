using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensEngine
    {
        Task<ILensResult> ExecuteAsync(
            ILensContext context,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default);
    }
}