using Nocturne.Abstractions.Surface;

namespace Nocturne.Surface.Diagnostics
{
    public enum SurfaceLogLevel
    {
        Info,
        Warn,
        Error,
        Debug
    }

    public sealed class SurfaceLogEntry : ISurfaceLogEntry
    {
        public DateTime Timestamp { get; }
        public string Message { get; }
        public string Category { get; }
        public IReadOnlyDictionary<string, object?>? Data { get; }

        public SurfaceLogEntry(string message, string category)
        {
            Timestamp = DateTime.UtcNow;
            Message = message;
            Category = category;
        }

        public SurfaceLogEntry(
            SurfaceLogLevel level,
            string message,
            IReadOnlyDictionary<string, object?>? data = null)
        {
            Timestamp = DateTime.UtcNow;
            Message = message;
            Category = level.ToString().ToLowerInvariant();
            Data = data;
        }
    }
}