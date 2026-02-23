using Nocturne.Abstractions;
using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Templates
{
    public abstract class BaseSpace : ISpace
    {
        public string Id { get; }
        public SpaceMetadata Metadata { get; }
        public IReadOnlyCollection<string> Tags => Metadata.Tags;

        public IReadOnlyCollection<IRegion> Regions { get; }

        protected BaseSpace(
            string id,
            SpaceMetadata metadata,
            IReadOnlyCollection<IRegion> regions)
        {
            Id = id;
            Metadata = metadata;
            Regions = regions;
        }
    }
}