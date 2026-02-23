using Nocturne.Surface.Validation;

namespace Nocturne.Surface.Abstractions
{
    public interface ISurfaceValidator
    {
        ValidationResult Validate(ISurface surface);
    }
}