using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Core
{
    internal sealed class SurfaceRegistry
    {
        private readonly Dictionary<string, ISurface> _surfaces = new();

        internal void Register(ISurface surface)
        {
            _surfaces[surface.Id] = surface;
        }

        internal bool TryGet(string id, out ISurface? surface)
        {
            return _surfaces.TryGetValue(id, out surface);
        }

        internal IReadOnlyCollection<ISurface> All => _surfaces.Values.ToArray();
    }
}