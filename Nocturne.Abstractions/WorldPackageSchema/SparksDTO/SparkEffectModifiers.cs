namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectModifiers(
        IReadOnlyList<string> AllowedModifiers,
        IReadOnlyList<string> ForbiddenModifiers,
        IReadOnlyList<string> OverlayModifiers
    );
}