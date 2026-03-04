using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Adapters;
using Nocturne.Genesis.Builders;
using Nocturne.Genesis.Config;
using Nocturne.Genesis.Engine;
using Nocturne.Genesis.Prompts;
using Nocturne.Genesis.Services;
using Nocturne.Genesis.Services.Lineage;

namespace Nocturne.Genesis.Factories
{
    public sealed class GenesisFactory : IGenesisFactory
    {
        private readonly GenesisConfig _config;

        public GenesisFactory(string configPath = "genesis.config.json")
        {
            _config = GenesisConfigLoader.Load(configPath);
        }

        public IGenesisEngine Create(ISurfaceArtifact seed, IGenesisOptions? options = null)
        {
            var mergedOfflineMode =
                options?.OfflineMode ?? _config.Defaults.OfflineMode;

            var mergedPromptSetPath =
                options?.PromptSetPath ?? _config.Defaults.PromptSetPath;

            var mergedLocalizationPath =
                options?.LocalizationPath ?? _config.Defaults.LocalizationPath;

            var promptSet = PromptSetLoader.Load(mergedPromptSetPath);
            var localization = PromptLocalizationLoader.Load(mergedLocalizationPath);

            var promptBuilder = new LlmPromptBuilder();

            var llmClient = new CopilotLlmClientBuilder()
                .UseHttpClient(new HttpClient())
                .UseEndpoint(_config.Llm.Endpoint)
                .UseApiKey(_config.Llm.ApiKey)
                .UseModel(_config.Llm.Model)
                .Build();

            var llm = new CopilotLlmAdapter(llmClient);

            var promptService = new GenesisPromptService(
                promptSet,
                localization,
                promptBuilder,
                llm,
                mergedOfflineMode
            );

            // lineage services
            var provenanceService = new ProvenanceService();
            var versioningService = new VersioningService();
            var fingerprintService = new FingerprintService();

            // builder now requires fingerprintService
            var builder = new GenesisBuilder(fingerprintService);

            var inference = new GenesisInferenceService();

            // NEW: concept service (this was missing)
            var conceptService = new GenesisConceptService(llm);

            // NEW: riffing service
            var riffService = new RiffService(new ApprovalService(
                versioningService,
                provenanceService,
                fingerprintService
            ));

            return new GenesisEngine(
                seed,
                promptService,
                inference,
                builder,
                provenanceService,
                versioningService,
                fingerprintService,
                conceptService,   // <-- FIXED: pass concept service, not riff service
                riffService
            );
        }
    }
}