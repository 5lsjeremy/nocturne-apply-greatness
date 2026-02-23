using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Abstractions
{
    public interface IRegionGraphBuilder
    {
        RegionGraph Build(IRegion region);
    }
}