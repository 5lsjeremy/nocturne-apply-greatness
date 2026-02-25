namespace Nocturne.Abstractions.Surface
{
    public interface IHasTags
    {
        IReadOnlyCollection<string> Tags { get; }
    }

}