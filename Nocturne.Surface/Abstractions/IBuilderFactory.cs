namespace Nocturne.Surface.Abstractions
{
    public interface IBuilderFactory<TBuilder>
    {
        TBuilder Create();
    }
}