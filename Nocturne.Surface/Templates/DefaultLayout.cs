using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;
using Nocturne.Surface.Layouts;

namespace Nocturne.Surface.Templates
{
    /// <summary>
    /// Default concrete Layout implementation using the MVP BaseLayout.
    /// </summary>
    public class DefaultLayout : BaseLayout
    {
        private static readonly LayoutMetadataBuilderFactory _factory = new();

        public DefaultLayout(
            string id,
            string type,
            Action<ILayoutMetadataBuilder> configure,
            IReadOnlyCollection<ILayoutSlot>? slots = null)
            : base(id, type, BuildMetadata(configure), slots)
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