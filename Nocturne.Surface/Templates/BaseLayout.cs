using Nocturne.Abstractions;
using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Layouts;

namespace Nocturne.Surface.Templates
{
    public abstract class BaseLayout : ILayout
    {
        public string Id { get; }
        public LayoutMetadata Metadata { get; }
        public IReadOnlyCollection<string> Tags => Metadata.Tags;

        protected BaseLayout(string id, LayoutMetadata metadata)
        {
            Id = id;
            Metadata = metadata;
        }
    }
}