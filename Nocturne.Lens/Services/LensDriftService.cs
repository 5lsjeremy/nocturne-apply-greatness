//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Lens.Enums;

namespace Nocturne.Lens.Services
{
    public sealed class LensDriftService : ILensDriftService
    {
        public IReadOnlyList<ILensDiagnosis> DetectDrift(ILensContext context)
        {
            var overlay = context.Overlay;

            context.Logger.Info("Running drift detection using overlay drift-sensitive tags.");

            // TODO: Implement drift detection logic
            // - Inspect context.Package.Domains / Concept / Presentation
            // - Compare key phrases / tags against overlay.SemanticTags / StructuralTags
            // - Use overlay.DriftSensitiveTags to decide what counts as “drift”
            // - For each drift, create a LensDiagnosis

            return Array.Empty<ILensDiagnosis>();
        }
    }
}