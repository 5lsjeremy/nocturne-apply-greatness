using Nocturne.Surface.Abstractions;
using System.Text.Json;
using Nocturne.Abstractions;

namespace Nocturne.Surface.Core
{
    internal sealed class SurfaceSerializer
    {
        internal string Serialize(ISurface surface)
        {
            return JsonSerializer.Serialize(surface.Metadata);
        }

        internal SurfaceMetadata DeserializeSurface(string json)
        {
            return JsonSerializer.Deserialize<SurfaceMetadata>(json)
                   ?? throw new InvalidOperationException("Invalid surface metadata");
        }
    }
}