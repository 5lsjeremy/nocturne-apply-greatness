//v.01 updated 26.03.18
using Microsoft.Extensions.DependencyInjection;
using Nocturne.Abstractions.Lens;
using Nocturne.Lens.Builders;
using Nocturne.Lens.Engine;
using Nocturne.Lens.Factories;
using Nocturne.Lens.Services;

namespace Nocturne.Lens.Initialization
{
    public static class LensServiceCollectionExtensions
    {
        public static IServiceCollection AddLens(this IServiceCollection services)
        {
            // Core
            services.AddSingleton<ILensEngine, LensEngine>();
            services.AddSingleton<ILensService, LensService>();

            // Builders
            services.AddSingleton<ILensResultBuilder, LensResultBuilder>();

            // Services
            services.AddSingleton<ILensDriftService, LensDriftService>();
            services.AddSingleton<ILensQuestionService, LensQuestionService>();
            services.AddSingleton<ILensUpdateHeuristicService, LensUpdateHeuristicService>();
            services.AddSingleton<ILensVersioningService, LensVersioningService>();
            services.AddSingleton<ILensDiffService, LensDiffService>();
            services.AddSingleton<ILensRiffCardSchema, LensRiffCardSchema>();
            services.AddSingleton<ILensRiffInterpreter, LensRiffInterpreter>();

            // Factories
            services.AddSingleton<ILensContextFactory, LensContextFactory>();

            return services;
        }
    }
}