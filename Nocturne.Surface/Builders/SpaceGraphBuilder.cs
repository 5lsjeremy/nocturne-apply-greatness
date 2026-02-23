using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Builders
{
    internal sealed class SpaceGraphBuilder : ISpaceGraphBuilder
    {
        private readonly IRegionGraphBuilder _regionGraphBuilder;

        public SpaceGraphBuilder(IRegionGraphBuilder regionGraphBuilder)
        {
            _regionGraphBuilder = regionGraphBuilder;
        }

        public SpaceGraph Build(ISpace space)
        {
            var regionGraphs = 
                space.Regions.
                    Select(region => _regionGraphBuilder.Build(region))
                    .ToList();

            return new SpaceGraph(
                space.Id,
                space.Metadata.Properties,
                regionGraphs);
        }
    }
}