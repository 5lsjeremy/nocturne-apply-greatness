namespace Nocturne.Abstractions
{
    public interface IHasMetadata<TMetadata>
    {
        TMetadata Metadata { get; }
    }

}