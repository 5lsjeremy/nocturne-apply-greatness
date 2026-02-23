using Nocturne.Surface.Validation;

namespace Nocturne.Surface.Abstractions
{
    public interface ISpaceValidator
    {
        ValidationResult Validate(ISpace space);
    }
}