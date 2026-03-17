using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO;
using Nocturne.Lens.Abstractions;
using Nocturne.Lens.Abstractions.Models;

namespace Nocturne.Lens.Factories;

internal sealed class LensContextFactory
{
    public ILensContext Create(
        UnifiedWorldPackageDto package,
        WorldPackageIndexDto index,
        IReadOnlyDictionary<string, object?> artifacts,
        string? focusId = null,
        IReadOnlyList<string>? activeDomains = null)
    {
        return new LensContext
        {
            Package = package,
            Index = index,
            Artifacts = artifacts,
            FocusId = focusId,
            ActiveDomains = activeDomains ?? index.Domains
        };
    }
}