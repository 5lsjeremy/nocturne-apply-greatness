namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectEvidence(
        IReadOnlyList<string> SimulationLogs,
        IReadOnlyList<string> DesignerNotes,
        IReadOnlyList<string> ObservedBehaviors
    );
}