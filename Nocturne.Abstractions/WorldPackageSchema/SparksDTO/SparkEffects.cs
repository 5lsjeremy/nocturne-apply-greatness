namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffects(
        SparkEffectIdentity Identity,
        SparkEffectType Type,
        SparkEffectTags Tags,
        SparkEffectTriggers Triggers,
        SparkEffectModifiers Modifiers,
        SparkEffectAccumulation Accumulation,
        SparkEffectLifespan Lifespan,
        SparkEffectState State,
        SparkEffectStrength Strength,
        SparkEffectDependencies Dependencies,
        SparkEffectVisibility Visibility,
        SparkEffectEvidence Evidence
    );
}