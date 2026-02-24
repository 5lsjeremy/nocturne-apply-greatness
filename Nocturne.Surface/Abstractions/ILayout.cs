using Nocturne.Abstractions;
using Nocturne.Surface.Layouts;

namespace Nocturne.Surface.Abstractions
{
    /// <summary>
    /// MVP Layout abstraction.
    /// A Layout describes the spatial arrangement of a Region.
    /// It is editor-facing only and does not affect runtime logic.
    /// </summary>
    public interface ILayout :
        IIdentifiable,
        IHasMetadata<LayoutMetadata>,
        IHasTags
    {
        /// <summary>
        /// The layout type: "slots", "grid", or "freeform".
        /// This is the minimal MVP set; more types can be added later.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Optional collection of slots.
        /// Only used when Type == "slots".
        /// For grid or freeform layouts, this may be null or empty.
        /// </summary>
        IReadOnlyCollection<ILayoutSlot> Slots { get; }
    }
}