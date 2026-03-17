using Nocturne.Abstractions.Lens.Enums;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensMutationRule
    {
        LensMutationType MutationType { get; }

        bool AppliesTo(ILensDiagnosis diagnosis);

        ILensPlannedUpdate CreateUpdate(
            ILensContext context,
            ILensDiagnosis diagnosis,
            ISurfaceLogger logger);
    }
}