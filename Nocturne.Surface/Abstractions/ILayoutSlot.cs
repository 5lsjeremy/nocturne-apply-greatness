using Nocturne.Abstractions;

namespace Nocturne.Surface.Abstractions
{
    /// <summary>
    /// A semantic position inside a Layout.
    /// MVP: just an ID, label, and optional allowed-entity tags.
    /// </summary>
    public interface ILayoutSlot :
        IIdentifiable,
        IHasTags
    {
        string Label { get; }

        /// <summary>
        /// Optional: restrict which entity types can occupy this slot.
        /// MVP: simple string identifiers; can evolve into richer constraints later.
        /// </summary>
        IReadOnlyCollection<string> AllowedEntities { get; }
    }
}