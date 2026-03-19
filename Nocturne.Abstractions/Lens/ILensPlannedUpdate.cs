using Nocturne.Abstractions.Lens.Enums;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensPlannedUpdate
    {
        string Id { get; }
        string TargetId { get; }
        LensMutationType MutationType { get; }
        object Payload { get; }
    }
}