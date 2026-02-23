using Nocturne.Abstractions;
using Nocturne.Surface.Layouts;

namespace Nocturne.Surface.Abstractions
{
    public interface ILayout :
        IIdentifiable,
        IHasMetadata<LayoutMetadata>,
        IHasTags
    {
    }
}