using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;

namespace Nocturne.Surface.Templates
{
    public abstract class RegionTemplate : DefaultRegion
    {
        protected RegionTemplate(
            string id,
            Action<IRegionMetadataBuilder> configure,
            IReadOnlyCollection<ILayout> layouts)
            : base(id, configure, layouts)
        {
        }
    }
}