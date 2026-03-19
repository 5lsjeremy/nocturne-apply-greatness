//v.01 updated 26.03.18
using Microsoft.Extensions.DependencyInjection;
using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Services;

namespace Nocturne.Genesis.Initialization
{
    public static class GenesisServiceCollectionExtensions
    {
        public static IServiceCollection AddGenesis(this IServiceCollection services)
        {
            // TODO: Add other Genesis services as they are migrated to DI

            services.AddSingleton<IGenesisLensQuestionService, GenesisLensQuestionService>();

            return services;
        }
    }
}