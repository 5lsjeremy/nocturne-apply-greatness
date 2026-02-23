using Nocturne.Surface.Regions;

namespace Nocturne.Surface.Abstractions
{
    public interface IRegionMetadataBuilder
    {
        IRegionMetadataBuilder WithName(string name);
        IRegionMetadataBuilder WithDescription(string description);
        IRegionMetadataBuilder AddTag(string tag);
        IRegionMetadataBuilder AddProperty(string key, object value);

        RegionMetadata Build();
    }
}