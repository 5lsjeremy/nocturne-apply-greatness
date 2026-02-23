using Nocturne.Abstractions;

namespace Nocturne.Surface.Builders
{
    public sealed class SurfaceMetadataBuilder
    {
        private string _name = string.Empty;
        private string _description = string.Empty;
        private readonly List<string> _tags = new();

        public SurfaceMetadataBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public SurfaceMetadataBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public SurfaceMetadataBuilder AddTag(string tag)
        {
            _tags.Add(tag);
            return this;
        }

        public SurfaceMetadata Build()
        {
            return new SurfaceMetadata(_name, _description, _tags);
        }
    }
}