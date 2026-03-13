namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkDefinition(
        string Id,
        string Slug,
        string ParentCardId,
        string ParentCardSlug,
        string Prompt,
        string SparkType,
        IReadOnlyList<string> Tags,
        bool OverlayEligible
    );
}