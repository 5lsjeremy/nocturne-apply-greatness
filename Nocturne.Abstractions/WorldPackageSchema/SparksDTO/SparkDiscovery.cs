namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkDiscovery(
        string Source,          // "lens", "prism", "designer"
        string Trigger,         // what caused it to emerge
        string Context,         // narrative or mechanical context
        IReadOnlyList<string> Evidence
    );
}