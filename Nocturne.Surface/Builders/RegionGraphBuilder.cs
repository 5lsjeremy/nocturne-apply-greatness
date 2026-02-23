using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Builders
{
    internal sealed class RegionGraphBuilder : IRegionGraphBuilder
    {
        private readonly ILayoutGraphBuilder _layoutGraphBuilder;

        public RegionGraphBuilder(ILayoutGraphBuilder layoutGraphBuilder)
        {
            _layoutGraphBuilder = layoutGraphBuilder;
        }

        public RegionGraph Build(IRegion region)
        {
            var layoutGraphs = new List<LayoutGraph>();

            foreach (var layout in region.Layouts)
            {
                var graph = _layoutGraphBuilder.Build(
                    layout.Id,
                    layout.Metadata.Properties);

                layoutGraphs.Add(graph);
            }

            return new RegionGraph(
                region.Id,
                region.Metadata.Properties,
                layoutGraphs);
        }
    }
}