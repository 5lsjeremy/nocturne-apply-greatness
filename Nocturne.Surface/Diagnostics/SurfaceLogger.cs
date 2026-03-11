using Nocturne.Abstractions.Genesis.Concepts.Enums;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Surface.Diagnostics
{
    public sealed class SurfaceLogger
    {
        private readonly List<ISurfaceLogEntry> _entries = new();

        public IReadOnlyCollection<ISurfaceLogEntry> Entries => _entries;

        public void Info(string message, string source = "surface")
        {
            _entries.Add(new SurfaceLogEntry(SurfaceLogLevel.Info, message, source));
        }

        public void Warn(string message, string source = "surface")
        {
            _entries.Add(new SurfaceLogEntry(SurfaceLogLevel.Warn, message, source));
        }

        public void Error(string message, string source = "surface")
        {
            _entries.Add(new SurfaceLogEntry(SurfaceLogLevel.Error, message, source));
        }
    }
}