using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;
using Nocturne.Surface.Layouts;

namespace Nocturne.Surface.Templates
{
    /// <summary>
    /// Base class for designer-authored layout templates.
    /// Wraps DefaultLayout but allows subclasses to define metadata and slots.
    /// </summary>
    public abstract class LayoutTemplate : DefaultLayout
    {
        protected LayoutTemplate(
            string id,
            string type,
            Action<ILayoutMetadataBuilder> configure,
            IReadOnlyCollection<ILayoutSlot>? slots = null)
            : base(id, type, configure, slots)
        {
        }
    }
}