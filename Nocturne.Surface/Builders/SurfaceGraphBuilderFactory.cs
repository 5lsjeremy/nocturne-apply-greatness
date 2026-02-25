using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Builders
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