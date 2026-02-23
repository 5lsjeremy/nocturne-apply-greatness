namespace Nocturne.Abstractions
{
    public sealed class SurfaceMetadata
    {
        public string Name { get; }
        public string Description { get; }
        public IReadOnlyCollection<string> Tags { get; }

        public SurfaceMetadata(string name, string description, IEnumerable<string> tags)
        {
            Name = name;
            Description = description;
            Tags = tags.ToArray();
        }
    }

}