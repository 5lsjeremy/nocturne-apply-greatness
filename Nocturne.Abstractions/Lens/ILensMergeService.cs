//v.01 updated 26.03.18

namespace Nocturne.Abstractions.Lens;

public interface ILensMergeService
{
    Task<ILensResult> ApplyAsync(
        ILensContext context,
        IEnumerable<ILensPlannedUpdate> updates,
        CancellationToken cancellationToken = default);
}