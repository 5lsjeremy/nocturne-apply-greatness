using Nocturne.Abstractions;
using Nocturne.Abstractions.Surface;
using Nocturne.Surface.Metadata;

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