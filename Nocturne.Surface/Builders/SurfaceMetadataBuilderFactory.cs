using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Builders
{
    public sealed class SurfaceMetadataBuilderFactory : IBuilderFactory<SurfaceMetadataBuilder>
    {
        public SurfaceMetadataBuilder Create()
        {
            return new SurfaceMetadataBuilder();
        }
    }
}