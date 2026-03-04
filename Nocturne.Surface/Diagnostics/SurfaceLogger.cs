using Nocturne.Abstractions.Surface;

namespace Nocturne.Surface.Diagnostics
{
    public sealed class SurfaceLogger
    {
        private readonly List<ISurfaceLogEntry> _entries = new();

        public IReadOnlyCollection<ISurfaceLogEntry> Entries => _entries;

        public void Info(string message)
        {
            _entries.Add(new SurfaceLogEntry(message, "info"));
        }

        public void Warn(string message)
        {
            _entries.Add(new SurfaceLogEntry(message, "warn"));
        }

        public void Error(string message)
        {
            _entries.Add(new SurfaceLogEntry(message, "error"));
        }
    }
}