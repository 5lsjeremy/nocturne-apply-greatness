//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO;
using Nocturne.Lens.Abstractions.Models;

namespace Nocturne.Lens.Factories
{
    public sealed class LensContextFactory : ILensContextFactory
    {
        public ILensContext Create(
            UnifiedWorldPackageDto package,
            WorldPackageIndexDto index,
            ILensOverlay overlay,
            ISurfaceLogger logger)
        {
            return new LensContext
            {
                Package = package,
                Index = index,
                ActiveDomains = index.Domains,
                Overlay = overlay,
                Logger = logger
            };
        }
    }
}