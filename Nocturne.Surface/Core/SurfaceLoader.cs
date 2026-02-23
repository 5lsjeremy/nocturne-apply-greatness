using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Exceptions;
using Nocturne.Surface.Graph;

namespace Nocturne.Surface.Core
{
    internal sealed class SurfaceLoader
    {
        private readonly SurfaceRegistry _registry;
        private readonly SurfaceValidationEngine _validator = new();
        private readonly SurfaceGraphBuilderFactory _graphFactory = new();

        internal SurfaceLoader(SurfaceRegistry registry)
        {
            _registry = registry;
        }

        internal SurfaceContext Load(ISurface surface)
        {
            // Build graph through factory
            ISurfaceGraphBuilder graphBuilder = _graphFactory.Create();
            var graph = graphBuilder.Build(surface);

            // Create context with graph
            var context = new SurfaceContext(surface, graph);

            context.Logger.Info($"Loading surface '{surface.Id}'");

            try
            {
                _validator.Validate(context);
            }
            catch (SurfaceException ex)
            {
                context.Logger.Error($"Validation failed for surface '{surface.Id}': {ex.Message}");
                throw new SurfaceLoadException($"Failed to load surface '{surface.Id}'", ex);
            }

            try
            {
                _registry.Register(surface);
                context.Logger.Info($"Registered surface '{surface.Id}'");
            }
            catch (Exception ex)
            {
                context.Logger.Error($"Registry failure for surface '{surface.Id}': {ex.Message}");
                throw new SurfaceLoadException($"Failed to register surface '{surface.Id}'", ex);
            }

            return context;
        }
    }
}