using Nocturne.Abstractions.Lens.Enums;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensPass
    {
        LensPassType PassType { get; }

        Task ExecuteAsync(
            ILensContext context,
            ILensResultBuilder resultBuilder,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default);
    }
}