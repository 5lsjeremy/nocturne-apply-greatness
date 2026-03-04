using Nocturne.Abstractions.Surface;

namespace Nocturne.Surface.Diagnostics
{
    public sealed class SurfaceLogEntry : ISurfaceLogEntry
    {
        public DateTime Timestamp { get; }
        public string Message { get; }
        public string Category { get; }

        public SurfaceLogEntry(string message, string category)
        {
            Timestamp = DateTime.UtcNow;
            Message = message;
            Category = category;
        }
    }
}