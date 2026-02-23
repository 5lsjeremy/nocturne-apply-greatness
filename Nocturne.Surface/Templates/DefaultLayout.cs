using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;
using Nocturne.Surface.Layouts;

namespace Nocturne.Surface.Templates
{
    public class DefaultLayout : BaseLayout
    {
        private static readonly LayoutMetadataBuilderFactory _factory = new();

        public DefaultLayout(
            string id,
            Action<ILayoutMetadataBuilder> configure)
            : base(id, BuildMetadata(configure))
        {
        }

        private static LayoutMetadata BuildMetadata(Action<ILayoutMetadataBuilder> configure)
        {
            var builder = _factory.Create();
            configure(builder);
            return builder.Build();
        }
    }
}