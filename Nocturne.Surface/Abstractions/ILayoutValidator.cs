using Nocturne.Surface.Validation;

namespace Nocturne.Surface.Abstractions
{
    public interface ILayoutValidator
    {
        ValidationResult Validate(ILayout layout);
    }
}