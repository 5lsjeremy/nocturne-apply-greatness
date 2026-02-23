using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Validation
{
    public sealed class DefaultSpaceValidator : ISpaceValidator
    {
        public ValidationResult Validate(ISpace space)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(space.Id))
                result.AddError("Space.Id cannot be null or empty.");

            return result;
        }
    }
}