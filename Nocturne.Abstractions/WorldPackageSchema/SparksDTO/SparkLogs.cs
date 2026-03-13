namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkLogs(
        IReadOnlyList<SparkLogEntry> Entries
    );
}