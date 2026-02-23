namespace Nocturne.Surface.Abstractions
{
    public interface IGraphBuilderFactory<TBuilder>
    {
        TBuilder Create();
    }
}