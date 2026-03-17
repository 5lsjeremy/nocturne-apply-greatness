using Nocturne.Abstractions.Lens.Enums;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensPassFactory
    {
        ILensPass Create(LensPassType type);
    }
}