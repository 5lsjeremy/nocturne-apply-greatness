namespace Nocturne.Abstractions.Surface
{
    public interface IHasMetadata<TMetadata>
    {
        TMetadata Metadata { get; }
    }

}