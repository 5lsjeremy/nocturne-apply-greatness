using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Validation
{
    public sealed class DefaultLayoutValidator : ILayoutValidator
    {
        public ValidationResult Validate(ILayout layout)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(layout.Id))
                result.AddError("Layout.Id cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(layout.Metadata.Name))
                result.AddWarning("Layout has no name.");

            return result;
        }
    }
}