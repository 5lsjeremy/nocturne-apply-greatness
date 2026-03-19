//v.01 updated 26.03.18
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensContext
    {
        UnifiedWorldPackageDto Package { get; }
        WorldPackageIndexDto Index { get; }
        IReadOnlyList<string> ActiveDomains { get; }

        ILensOverlay Overlay { get; }     // ← NEW: semantic profile
        ISurfaceLogger Logger { get; }
    }
}