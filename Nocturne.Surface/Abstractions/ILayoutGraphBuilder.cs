using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Abstractions
{
    public interface ILayoutGraphBuilder
    {
        LayoutGraph Build(string id, IReadOnlyDictionary<string, object> properties);
    }
}