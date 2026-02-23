using Nocturne.Surface.Validation;

namespace Nocturne.Surface.Abstractions
{
    public interface IRegionValidator
    {
        ValidationResult Validate(IRegion region);
    }
}