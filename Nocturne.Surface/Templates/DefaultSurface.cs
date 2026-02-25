using Nocturne.Abstractions;
using Nocturne.Surface.Builders;
using Nocturne.Surface.Metadata;

namespace Nocturne.Surface.Templates
{
    public class DefaultSurface : BaseSurface
    {
        private static readonly SurfaceMetadataBuilderFactory _factory = new();

        public DefaultSurface(string id, Action<SurfaceMetadataBuilder> configure)
            : base(id, BuildMetadata(configure))
        {
        }

        private static SurfaceMetadata BuildMetadata(Action<SurfaceMetadataBuilder> configure)
        {
            var builder = _factory.Create();
            configure(builder);
            return builder.Build();
        }
    }
}