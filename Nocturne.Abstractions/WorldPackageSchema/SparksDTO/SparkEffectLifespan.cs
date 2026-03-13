namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectLifespan(
        string DurationType, // "temporary", "persistent", "permanent", "decaying"
        TimeSpan? Duration,
        DateTime CreatedAt,
        DateTime? ExpiresAt
    );
}