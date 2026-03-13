namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectState(
        string CurrentState, // "active", "dormant", "suppressed", "decaying", "retired"
        DateTime LastStateChange
    );
}