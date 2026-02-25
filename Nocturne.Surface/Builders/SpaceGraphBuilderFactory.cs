using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Builders
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