using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Builders
{
    public sealed class LayoutMetadataBuilderFactory
        : IBuilderFactory<ILayoutMetadataBuilder>
    {
        public ILayoutMetadataBuilder Create()
        {
            return new LayoutMetadataBuilder();
        }
    }
}