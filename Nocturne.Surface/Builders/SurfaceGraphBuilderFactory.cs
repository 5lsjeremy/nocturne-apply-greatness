using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Graph
{
    public sealed class SurfaceGraphBuilderFactory 
        : IGraphBuilderFactory<ISurfaceGraphBuilder>
    {
        public ISurfaceGraphBuilder Create()
        {
            return new SurfaceGraphBuilder();
        }
    }
}