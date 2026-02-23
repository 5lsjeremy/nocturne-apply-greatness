using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;

namespace Nocturne.Surface.Templates
{
    public abstract class SpaceTemplate : DefaultSpace
    {
        protected SpaceTemplate(
            string id,
            Action<ISpaceMetadataBuilder> configure,
            IReadOnlyCollection<IRegion> regions)
            : base(id, configure, regions)
        {
        }
    }
}