namespace Nocturne.Abstractions
{
    public interface IHasTags
    {
        IReadOnlyCollection<string> Tags { get; }
    }

}