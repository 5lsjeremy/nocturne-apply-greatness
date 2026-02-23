namespace Nocturne.Surface.Graph
{
    public sealed class LayoutGraph
    {
        public string Id { get; }
        public IReadOnlyDictionary<string, object> Properties { get; }

        public LayoutGraph(
            string id,
            IReadOnlyDictionary<string, object> properties)
        {
            Id = id;
            Properties = properties;
        }
    }
}