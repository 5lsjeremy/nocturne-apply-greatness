using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Abstractions
{
    public interface ISurfaceGraphBuilder
    {
        SurfaceGraph Build(ISurface surface);
    }
}