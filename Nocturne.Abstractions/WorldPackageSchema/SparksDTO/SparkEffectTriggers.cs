namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectTriggers(
        IReadOnlyList<string> ActivationStates,
        IReadOnlyList<string> SuppressionStates,
        IReadOnlyList<string> ModificationStates
    );
}