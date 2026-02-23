namespace Nocturne.Abstractions
{
    public sealed class SpaceMetadata
    {
        public string Name { get; }
        public string Description { get; }
        public IReadOnlyCollection<string> Tags { get; }
        public IReadOnlyDictionary<string, object> Properties { get; }

        public SpaceMetadata(
            string name,
            string description,
            IEnumerable<string> tags,
            IReadOnlyDictionary<string, object> properties)
        {
            Name = name;
            Description = description;
            Tags = tags.ToArray();
            Properties = properties;
        }
    }
}