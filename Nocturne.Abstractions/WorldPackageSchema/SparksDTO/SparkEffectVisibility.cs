namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectVisibility(
        bool VisibleToDesigner,
        bool VisibleToSimulation,
        bool VisibleToOverlays,
        bool VisibleInStarterPack
    );
}