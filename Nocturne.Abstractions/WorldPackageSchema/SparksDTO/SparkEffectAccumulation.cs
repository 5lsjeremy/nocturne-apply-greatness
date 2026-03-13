namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectAccumulation(
        float StabilityContribution,
        float PressureContribution,
        float DriftContribution,
        string Category
    );
}