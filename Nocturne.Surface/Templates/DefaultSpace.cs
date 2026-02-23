using Nocturne.Abstractions;
using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;

namespace Nocturne.Surface.Templates
{
    public class DefaultSpace : BaseSpace
    {
        private static readonly SpaceMetadataBuilderFactory _factory = new();

        public DefaultSpace(
            string id,
            Action<ISpaceMetadataBuilder> configure,
            IReadOnlyCollection<IRegion> regions)
            : base(id, BuildMetadata(configure), regions)
        {
        }

        private static SpaceMetadata BuildMetadata(Action<ISpaceMetadataBuilder> configure)
        {
            var builder = _factory.Create();
            configure(builder);
            return builder.Build();
        }
    }
}