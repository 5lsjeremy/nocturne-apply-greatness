namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectDependencies(
        IReadOnlyList<string> RequiredEffects,
        IReadOnlyList<string> ConflictingEffects,
        IReadOnlyList<string> RequiredDomainStates,
        IReadOnlyList<string> RequiredCardStates
    );
}