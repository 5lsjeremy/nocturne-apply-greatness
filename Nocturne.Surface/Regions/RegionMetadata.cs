namespace Nocturne.Surface.Regions
{
    public sealed class RegionMetadata
    {
        public string Name { get; }
        public string Description { get; }
        public IReadOnlyCollection<string> Tags { get; }
        public IReadOnlyDictionary<string, object> Properties { get; }

        public RegionMetadata(
            string name,
            string description,
            IReadOnlyCollection<string> tags,
            IReadOnlyDictionary<string, object> properties)
        {
            Name = name;
            Description = description;
            Tags = tags;
            Properties = properties;
        }
    }
}