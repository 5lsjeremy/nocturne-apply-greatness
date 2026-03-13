namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkDTO(
        string Id,
        string Slug,
        string Prompt,
        string SparkType,
        IReadOnlyList<string> Tags,
        bool OverlayEligible
    );
}