using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Builders
{
    public sealed class SpaceMetadataBuilderFactory
        : IBuilderFactory<ISpaceMetadataBuilder>
    {
        public ISpaceMetadataBuilder Create()
        {
            return new SpaceMetadataBuilder();
        }
    }
}