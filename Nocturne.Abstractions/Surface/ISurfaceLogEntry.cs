namespace Nocturne.Abstractions.Surface
{
    public interface ISurfaceLogEntry
    {
        DateTime Timestamp { get; }
        string Message { get; }
        string Category { get; }
        string Source { get; }
    }
}