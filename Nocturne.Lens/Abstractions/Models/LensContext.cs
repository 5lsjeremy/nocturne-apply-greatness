using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO;

namespace Nocturne.Lens.Abstractions.Models
{
    internal sealed class LensContext : ILensContext
    {
        public UnifiedWorldPackageDto Package { get; init; } = default!;
        public WorldPackageIndexDto Index { get; init; } = default!;
        public IReadOnlyDictionary<string, object?> Artifacts { get; init; } = default!;
        public string? FocusId { get; init; }
        public IReadOnlyList<string> ActiveDomains { get; init; } = Array.Empty<string>();
    }
}