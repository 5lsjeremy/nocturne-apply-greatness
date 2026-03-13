namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkMetadata(
        string Title,
        string Description,
        string Category,
        IReadOnlyList<string> Keywords,
        string Lore,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}