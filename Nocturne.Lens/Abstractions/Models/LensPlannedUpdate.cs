//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Lens.Enums;

namespace Nocturne.Lens.Abstractions.Models
{
    internal sealed class LensPlannedUpdate : ILensPlannedUpdate
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public string TargetId { get; init; } = string.Empty;
        public LensMutationType MutationType { get; init; }
        public object Payload { get; init; } = default!;
    }
}