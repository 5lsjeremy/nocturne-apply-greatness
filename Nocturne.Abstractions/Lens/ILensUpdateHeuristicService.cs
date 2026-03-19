//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensUpdateHeuristicService
    {
        IReadOnlyList<ILensPlannedUpdate> ProposeUpdates(ILensContext context);
    }
}