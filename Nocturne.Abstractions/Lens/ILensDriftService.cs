//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensDriftService
    {
        IReadOnlyList<ILensDiagnosis> DetectDrift(ILensContext context);
    }
}