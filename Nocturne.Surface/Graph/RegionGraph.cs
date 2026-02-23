using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Graph
{
    public sealed class RegionGraph
    {
        public string Id { get; }
        public IReadOnlyDictionary<string, object> Properties { get; }
        public IReadOnlyCollection<LayoutGraph> Layouts { get; }

        public RegionGraph(
            string id,
            IReadOnlyDictionary<string, object> properties,
            IReadOnlyCollection<LayoutGraph> layouts)
        {
            Id = id;
            Properties = properties;
            Layouts = layouts;
        }
    }
}