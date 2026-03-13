namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkLogEntry(
        DateTime Timestamp,
        string Message,
        string Severity
    );
}