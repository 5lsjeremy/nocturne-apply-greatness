using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;

namespace Nocturne.Surface.Graph
{
    public sealed class SpaceGraphBuilderFactory
        : IGraphBuilderFactory<ISpaceGraphBuilder>
    {
        private readonly RegionGraphBuilderFactory _regionFactory = new();

        public ISpaceGraphBuilder Create()
        {
            return new SpaceGraphBuilder(_regionFactory.Create());
        }
    }
}