using Nocturne.Abstractions;
using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Layouts;

namespace Nocturne.Surface.Templates
{
    /// <summary>
    /// MVP base class for Layouts.
    /// Implements the minimal ILayout contract:
    /// - Id
    /// - Metadata
    /// - Tags
    /// - Type ("slots", "grid", "freeform")
    /// - Slots (only used when Type == "slots")
    /// </summary>
    public abstract class BaseLayout : ILayout
    {
        public string Id { get; }
        public LayoutMetadata Metadata { get; }
        public IReadOnlyCollection<string> Tags => Metadata.Tags;

        /// <summary>
        /// MVP layout type: "slots", "grid", or "freeform".
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Optional slot collection.
        /// Only meaningful when Type == "slots".
        /// </summary>
        public IReadOnlyCollection<ILayoutSlot> Slots { get; }

        protected BaseLayout(
            string id,
            string type,
            LayoutMetadata metadata,
            IReadOnlyCollection<ILayoutSlot>? slots = null)
        {
            Id = id;
            Type = type;
            Metadata = metadata;
            Slots = slots ?? Array.Empty<ILayoutSlot>();
        }
    }
}