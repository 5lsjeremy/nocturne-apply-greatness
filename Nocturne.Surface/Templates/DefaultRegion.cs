using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;
using Nocturne.Surface.Regions;

namespace Nocturne.Surface.Templates
{
    public class DefaultRegion : BaseRegion
    {
        private static readonly RegionMetadataBuilderFactory _factory = new();

        public DefaultRegion(
            string id,
            Action<IRegionMetadataBuilder> configure,
            IReadOnlyCollection<ILayout> layouts)
            : base(id, BuildMetadata(configure), layouts)
        {
        }

        private static RegionMetadata BuildMetadata(Action<IRegionMetadataBuilder> configure)
        {
            var builder = _factory.Create();
            configure(builder);
            return builder.Build();
        }
    }
}