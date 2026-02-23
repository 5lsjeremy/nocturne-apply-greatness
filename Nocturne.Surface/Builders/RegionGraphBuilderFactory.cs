using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Builders
{
    public sealed class RegionGraphBuilderFactory
        : IGraphBuilderFactory<IRegionGraphBuilder>
    {
        private readonly LayoutGraphBuilderFactory _layoutFactory = new();

        public IRegionGraphBuilder Create()
        {
            return new RegionGraphBuilder(_layoutFactory.Create());
        }
    }
}