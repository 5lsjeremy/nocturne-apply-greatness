using Nocturne.Abstractions;
using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Metadata;

namespace Nocturne.Surface.Templates
{
    public abstract class BaseSurface : ISurface
    {
        public string Id { get; }
        public SurfaceMetadata Metadata { get; }
        public IReadOnlyCollection<string> Tags => Metadata.Tags;

        protected readonly List<ISpace> _spaces = new();

        public IReadOnlyCollection<ISpace> Spaces => _spaces;

        protected BaseSurface(string id, SurfaceMetadata metadata)
        {
            Id = id;
            Metadata = metadata;
        }

        protected void AddSpace(ISpace space)
        {
            _spaces.Add(space);
        }
    }

}