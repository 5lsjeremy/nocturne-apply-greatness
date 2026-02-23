using Nocturne.Abstractions;
using Nocturne.Surface.Regions;

namespace Nocturne.Surface.Abstractions
{
    public interface IRegion :
        IIdentifiable,
        IHasMetadata<RegionMetadata>,
        IHasTags
    {
        IReadOnlyCollection<ILayout> Layouts { get; }
    }
}