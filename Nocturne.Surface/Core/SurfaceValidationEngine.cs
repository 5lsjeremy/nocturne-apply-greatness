using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Diagnostics;
using Nocturne.Surface.Validation;

namespace Nocturne.Surface.Core
{
    internal sealed class SurfaceValidationEngine
    {
        private readonly ISurfaceValidator _surfaceValidator = new DefaultSurfaceValidator();
        private readonly ISpaceValidator _spaceValidator = new DefaultSpaceValidator();
        private readonly IRegionValidator _regionValidator = new DefaultRegionValidator();

        internal void Validate(SurfaceContext context)
        {
            var surface = context.Surface;

            // Validate surface
            var surfaceResult = _surfaceValidator.Validate(surface);
            LogResult(context.Logger, surface.Id, surfaceResult);

            // Validate spaces
            foreach (var space in surface.Spaces)
            {
                var spaceResult = _spaceValidator.Validate(space);
                LogResult(context.Logger, space.Id, spaceResult);

                // Validate regions inside each space
                foreach (var region in space.Regions)
                {
                    var regionResult = _regionValidator.Validate(region);
                    LogResult(context.Logger, region.Id, regionResult);
                }
            }
        }

        private static void LogResult(SurfaceLogger logger, string id, ValidationResult result)
        {
            foreach (var error in result.Errors)
                logger.Error($"Validation error in '{id}': {error}");

            foreach (var warning in result.Warnings)
                logger.Warn($"Validation warning in '{id}': {warning}");
        }
    }
}