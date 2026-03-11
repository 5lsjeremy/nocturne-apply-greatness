using Nocturne.Abstractions.Genesis.Concepts.Enums;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Surface.Diagnostics
{
    public sealed class SurfaceLogEntry : ISurfaceLogEntry
    {
        public DateTime Timestamp { get; }
        public string Message { get; }
        public string Category { get; }
        public string Source { get; }
        public IReadOnlyDictionary<string, object?>? Data { get; }

        public SurfaceLogEntry(
            SurfaceLogLevel level,
            string message,
            string source,
            IReadOnlyDictionary<string, object?>? data = null)
        {
            Timestamp = DateTime.UtcNow;
            Message = message;
            Category = level.ToString().ToLowerInvariant();
            Source = source;
            Data = data;
        }
    }
}