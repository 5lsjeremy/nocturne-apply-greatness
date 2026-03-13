namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectStrength(
        float BaseStrength,
        string CurveType, // "linear", "exponential", "logarithmic", "spike", "oscillating"
        IReadOnlyDictionary<string, float> CurveParameters
    );
}