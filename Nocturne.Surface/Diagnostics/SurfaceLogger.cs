namespace Nocturne.Surface.Diagnostics
{
    public sealed class SurfaceLogger
    {
        private readonly List<SurfaceLogEntry> _entries = new();

        public IReadOnlyCollection<SurfaceLogEntry> Entries => _entries;

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