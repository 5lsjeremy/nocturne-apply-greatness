using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Builders
{
    internal sealed class SurfaceGraphBuilder : ISurfaceGraphBuilder
    {
        private readonly SpaceGraphBuilderFactory _spaceFactory = new();

        public SurfaceGraph Build(ISurface surface)
        {
            var spaceBuilder = _spaceFactory.Create();

            var spaces = surface.Spaces
                .Select(s => spaceBuilder.Build(s))
                .ToArray();

            return new SurfaceGraph(
                surface.Id,
                surface.Metadata,
                spaces);
        }
    }
}