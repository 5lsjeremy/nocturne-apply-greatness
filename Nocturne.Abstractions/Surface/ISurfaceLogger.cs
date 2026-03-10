namespace Nocturne.Abstractions.Surface
{
    public interface ISurfaceLogger
    {
        IReadOnlyCollection<ISurfaceLogEntry> Entries { get; }

        void Info(string message);
        void Warn(string message);
        void Error(string message);
    }
}