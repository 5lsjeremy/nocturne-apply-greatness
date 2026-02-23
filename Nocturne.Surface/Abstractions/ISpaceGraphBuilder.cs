using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Abstractions
{
    public interface ISpaceGraphBuilder
    {
        SpaceGraph Build(ISpace space);
    }
}