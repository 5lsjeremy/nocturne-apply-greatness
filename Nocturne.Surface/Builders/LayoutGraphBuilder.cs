using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Builders
{
    internal sealed class LayoutGraphBuilder : ILayoutGraphBuilder
    {
        public LayoutGraph Build(string id, IReadOnlyDictionary<string, object> properties)
        {
            return new LayoutGraph(id, properties);
        }
    }
}