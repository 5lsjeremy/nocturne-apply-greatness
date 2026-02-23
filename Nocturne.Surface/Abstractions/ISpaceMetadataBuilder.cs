using Nocturne.Abstractions;

namespace Nocturne.Surface.Abstractions
{
    public interface ISpaceMetadataBuilder
    {
        ISpaceMetadataBuilder WithName(string name);
        ISpaceMetadataBuilder WithDescription(string description);
        ISpaceMetadataBuilder AddTag(string tag);
        ISpaceMetadataBuilder AddProperty(string key, object value);

        SpaceMetadata Build();
    }
}