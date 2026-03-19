//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;

namespace Nocturne.Lens.Abstractions.Models
{
//v.01 updated 26.03.18
    public sealed class LensResult : ILensResult
    {
        public IReadOnlyList<ILensDiagnosis> Diagnoses { get; init; }
            = Array.Empty<ILensDiagnosis>();

        public IReadOnlyList<ILensQuestion> Questions { get; init; }
            = Array.Empty<ILensQuestion>();

        public IReadOnlyList<ILensPlannedUpdate> PlannedUpdates { get; init; }
            = Array.Empty<ILensPlannedUpdate>();
    }
}