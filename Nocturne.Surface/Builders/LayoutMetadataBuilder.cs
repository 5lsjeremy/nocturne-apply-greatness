using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Layouts;

namespace Nocturne.Surface.Builders
{
    internal sealed class LayoutMetadataBuilder : ILayoutMetadataBuilder
    {
        private string _name = string.Empty;
        private string _description = string.Empty;
        private readonly List<string> _tags = new();
        private readonly Dictionary<string, object> _properties = new();

        public ILayoutMetadataBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ILayoutMetadataBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ILayoutMetadataBuilder AddTag(string tag)
        {
            _tags.Add(tag);
            return this;
        }

        public ILayoutMetadataBuilder AddProperty(string key, object value)
        {
            _properties[key] = value;
            return this;
        }

        public LayoutMetadata Build()
        {
            return new LayoutMetadata(
                _name,
                _description,
                _tags.ToArray(),
                new Dictionary<string, object>(_properties));
        }
    }
}