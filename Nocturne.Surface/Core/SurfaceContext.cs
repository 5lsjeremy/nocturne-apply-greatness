using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Diagnostics;
using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Core
{
    internal sealed class SurfaceContext
    {
        internal ISurface Surface { get; }
        internal IReadOnlyCollection<SpaceContext> Spaces { get; }
        internal SurfaceLogger Logger { get; }
        internal SurfaceGraph Graph { get; }

        internal SurfaceContext(ISurface surface, SurfaceGraph graph)
        {
            Surface = surface;
            Graph = graph;
            Logger = new SurfaceLogger();

            Logger.Info($"Initialized SurfaceContext for surface '{surface.Id}'");

            Spaces = surface.Spaces
                .Select(s => new SpaceContext(s))
                .ToArray();
        }
    }
}