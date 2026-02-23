using Nocturne.Abstractions;

namespace Nocturne.Surface.Abstractions
{
    public interface ISpace :
        IIdentifiable,
        IHasMetadata<SpaceMetadata>,
        IHasTags
    {
        IReadOnlyCollection<IRegion> Regions { get; }
    }
}