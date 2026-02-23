using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Regions;

namespace Nocturne.Surface.Builders
{
    internal sealed class RegionMetadataBuilder : IRegionMetadataBuilder
    {
        private string _name = string.Empty;
        private string _description = string.Empty;
        private readonly List<string> _tags = new();
        private readonly Dictionary<string, object> _properties = new();

        public IRegionMetadataBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public IRegionMetadataBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public IRegionMetadataBuilder AddTag(string tag)
        {
            _tags.Add(tag);
            return this;
        }

        public IRegionMetadataBuilder AddProperty(string key, object value)
        {
            _properties[key] = value;
            return this;
        }

        public RegionMetadata Build()
        {
            return new RegionMetadata(
                _name,
                _description,
                _tags.ToArray(),
                new Dictionary<string, object>(_properties));
        }
    }
}