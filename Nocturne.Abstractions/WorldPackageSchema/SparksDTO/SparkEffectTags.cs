namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectTags(
        IReadOnlyList<string> InheritedTags,
        IReadOnlyList<string> GeneratedTags,
        IReadOnlyList<string> DomainTags
    );
}