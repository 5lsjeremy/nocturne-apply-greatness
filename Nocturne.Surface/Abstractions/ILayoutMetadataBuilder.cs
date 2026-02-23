using Nocturne.Surface.Layouts;

namespace Nocturne.Surface.Abstractions
{
    public interface ILayoutMetadataBuilder
    {
        ILayoutMetadataBuilder WithName(string name);
        ILayoutMetadataBuilder WithDescription(string description);
        ILayoutMetadataBuilder AddTag(string tag);
        ILayoutMetadataBuilder AddProperty(string key, object value);

        LayoutMetadata Build();
    }
}