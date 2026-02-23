using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.Validation
{
    public sealed class DefaultRegionValidator : IRegionValidator
    {
        public ValidationResult Validate(IRegion region)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(region.Id))
                result.AddError("Region.Id cannot be null or empty.");

            if (region.Metadata == null)
                result.AddError("Region.Metadata cannot be null.");

            if (region.Layouts == null)
                result.AddWarning("Region has no layouts collection.");

            return result;
        }
    }
}