//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;

namespace Nocturne.Lens.Abstractions.Models
{
    internal sealed class LensRollbackResult : ILensRollbackResult
    {
        public ILensContext RestoredContext { get; init; } = default!;
        public ILensResult RestoredResult { get; init; } = default!;
        public ILensVersionInfo VersionInfo { get; init; } = default!;
    }
}