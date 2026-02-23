using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Diagnostics;
using Nocturne.Surface.Regions;

namespace Nocturne.Surface.Core
{
    internal sealed class RegionContext
    {
        internal IRegion Region { get; }
        internal RegionMetadata Metadata => Region.Metadata;
        internal SurfaceLogger Logger { get; }

        internal RegionContext(IRegion region)
        {
            Region = region;
            Logger = new SurfaceLogger();
            Logger.Info($"Initialized RegionContext for region '{region.Id}'");
        }
    }
}