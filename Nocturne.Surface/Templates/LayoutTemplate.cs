using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;

namespace Nocturne.Surface.Templates
{
    public abstract class LayoutTemplate : DefaultLayout
    {
        protected LayoutTemplate(
            string id,
            Action<ILayoutMetadataBuilder> configure)
            : base(id, configure)
        {
        }
    }
}