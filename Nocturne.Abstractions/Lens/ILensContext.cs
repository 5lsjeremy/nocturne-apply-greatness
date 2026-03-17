using Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensContext
    {
        UnifiedWorldPackageDto Package { get; }
        WorldPackageIndexDto Index { get; }
        IReadOnlyDictionary<string, object?> Artifacts { get; }
        string? FocusId { get; }
        IReadOnlyList<string> ActiveDomains { get; }
    }
}