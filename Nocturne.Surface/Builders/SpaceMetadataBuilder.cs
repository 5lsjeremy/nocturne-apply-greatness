using Nocturne.Abstractions;
using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Metadata;

namespace Nocturne.Surface.Builders
{
    internal sealed class SpaceMetadataBuilder : ISpaceMetadataBuilder
    {
        private string _name = string.Empty;
        private string _description = string.Empty;
        private readonly List<string> _tags = new();
        private readonly Dictionary<string, object> _properties = new();

        public ISpaceMetadataBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ISpaceMetadataBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ISpaceMetadataBuilder AddTag(string tag)
        {
            _tags.Add(tag);
            return this;
        }

        public ISpaceMetadataBuilder AddProperty(string key, object value)
        {
            _properties[key] = value;
            return this;
        }

        public SpaceMetadata Build()
        {
            return new SpaceMetadata(
                _name,
                _description,
                _tags.ToArray(),
                new Dictionary<string, object>(_properties));
        }
    }
}