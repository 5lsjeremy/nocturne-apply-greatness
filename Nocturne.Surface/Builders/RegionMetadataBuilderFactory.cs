using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Builders
{
    public sealed class RegionMetadataBuilderFactory 
        : IBuilderFactory<IRegionMetadataBuilder>
    {
        public IRegionMetadataBuilder Create()
        {
            return new RegionMetadataBuilder();
        }
    }
}