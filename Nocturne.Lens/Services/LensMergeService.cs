//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;
using Nocturne.Lens.Abstractions.Models;

namespace Nocturne.Lens.Services
{
    public sealed class LensMergeService : ILensMergeService
    {
        public Task<ILensResult> ApplyAsync(
            ILensContext context,
            IEnumerable<ILensPlannedUpdate> updates,
            CancellationToken cancellationToken = default)
        {
            var overlay = context.Overlay;

            context.Logger.Info("Applying Lens planned updates influenced by overlay heuristics.");

            // TODO: Implement merge logic
            // - Iterate updates
            // - Apply mutations to the world package
            // - Use overlay.UpdateHeuristicTags to prioritize or filter updates
            // - Produce a new LensResult with updated Diagnoses, Questions, PlannedUpdates

            return Task.FromResult<ILensResult>(new LensResult
            {
                Diagnoses = Array.Empty<ILensDiagnosis>(),
                Questions = Array.Empty<ILensQuestion>(),
                PlannedUpdates = updates.ToList()
            });
        }
    }
}