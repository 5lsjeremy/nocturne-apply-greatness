using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Surface.Diagnostics
{
    public sealed class SurfaceLogger : ISurfaceLogger
    {
        private readonly List<ISurfaceLogEntry> _entries = new();

        public IReadOnlyCollection<ISurfaceLogEntry> Entries => _entries;

        public void Info(string message)
        {
            Add(SurfaceLogLevel.Info, message, "surface");
        }

        public void Warn(string message)
        {
            Add(SurfaceLogLevel.Warn, message, "surface");
        }

        public void Error(string message)
        {
            Add(SurfaceLogLevel.Error, message, "surface");
        }

        private void Add(SurfaceLogLevel level, string message, string source)
        {
            _entries.Add(new SurfaceLogEntry(level, message, source));
        }
    }
}