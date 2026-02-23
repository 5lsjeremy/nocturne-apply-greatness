using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Builders
{
    public sealed class LayoutGraphBuilderFactory
        : IGraphBuilderFactory<ILayoutGraphBuilder>
    {
        public ILayoutGraphBuilder Create()
        {
            return new LayoutGraphBuilder();
        }
    }
}