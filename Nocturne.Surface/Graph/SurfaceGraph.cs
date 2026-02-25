using Nocturne.Abstractions;
using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Metadata;

namespace Nocturne.Surface.Graph
{
    public sealed class SurfaceGraph
    {
        public string Id { get; }
        public SurfaceMetadata Metadata { get; }
        public IReadOnlyCollection<SpaceGraph> Spaces { get; }

        public SurfaceGraph(
            string id,
            SurfaceMetadata metadata,
            IReadOnlyCollection<SpaceGraph> spaces)
        {
            Id = id;
            Metadata = metadata;
            Spaces = spaces;
        }
    }
}