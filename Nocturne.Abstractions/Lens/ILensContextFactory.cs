//v.01 updated 26.03.18

using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO;

namespace Nocturne.Abstractions.Lens;

public interface ILensContextFactory
{
    ILensContext Create(
        UnifiedWorldPackageDto package,
        WorldPackageIndexDto index,
        ILensOverlay overlay,
        ISurfaceLogger logger);
}