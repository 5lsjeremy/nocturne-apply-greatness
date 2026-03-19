//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO;

namespace Nocturne.Lens.Abstractions.Models
{
    internal sealed class LensContext : ILensContext
    {
        public UnifiedWorldPackageDto Package { get; init; } = default!;
        public WorldPackageIndexDto Index { get; init; } = default!;
        public IReadOnlyList<string> ActiveDomains { get; init; } = Array.Empty<string>();

        public ILensOverlay Overlay { get; init; } = default!;   // ← NEW

        public ISurfaceLogger Logger { get; init; } = default!;
    }
}