using Nocturne.Abstractions;
using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Graph
{
    public sealed class SpaceGraph
    {
        public string Id { get; }
        public IReadOnlyDictionary<string, object> Properties { get; }
        public IReadOnlyCollection<RegionGraph> Regions { get; }

        public SpaceGraph(
            string id,
            IReadOnlyDictionary<string, object> properties,
            IReadOnlyCollection<RegionGraph> regions)
        {
            Id = id;
            Properties = properties;
            Regions = regions;
        }
    }
}