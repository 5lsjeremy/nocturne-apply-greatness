using Nocturne.Abstractions;
using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Regions;

namespace Nocturne.Surface.Templates
{
    public abstract class BaseRegion : IRegion
    {
        public string Id { get; }
        public RegionMetadata Metadata { get; }
        public IReadOnlyCollection<string> Tags => Metadata.Tags;

        public IReadOnlyCollection<ILayout> Layouts { get; }

        protected BaseRegion(
            string id,
            RegionMetadata metadata,
            IReadOnlyCollection<ILayout> layouts)
        {
            Id = id;
            Metadata = metadata;
            Layouts = layouts;
        }
    }
}