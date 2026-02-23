using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Validation
{
    public sealed class DefaultSurfaceValidator : ISurfaceValidator
    {
        public ValidationResult Validate(ISurface surface)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(surface.Id))
                result.AddError("Surface.Id cannot be null or empty.");

            if (surface.Spaces.Count == 0)
                result.AddWarning("Surface has no spaces defined.");

            return result;
        }
    }
}