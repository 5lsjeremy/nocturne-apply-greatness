//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Lens.Enums;
using Nocturne.Lens.Abstractions.Models;

namespace Nocturne.Lens.Services
{
    public sealed class LensUpdateHeuristicService : ILensUpdateHeuristicService
    {
        public IReadOnlyList<ILensPlannedUpdate> ProposeUpdates(ILensContext context)
        {
            var overlay = context.Overlay;

            context.Logger.Info("Proposing updates using overlay update-heuristic tags.");

            // TODO: Implement update heuristics
            // - For each overlay.UpdateHeuristicTag, decide:
            //     * which domain / artifact to touch
            //     * what mutation type (e.g., LensMutationType.UpdateText)
            //     * what payload shape
            // - Return a list of LensPlannedUpdate

            return Array.Empty<ILensPlannedUpdate>();
        }
    }
}