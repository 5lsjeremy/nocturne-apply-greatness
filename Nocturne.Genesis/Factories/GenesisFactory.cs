using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Genesis.Adapters;
using Nocturne.Genesis.Builders;
using Nocturne.Genesis.Config;
using Nocturne.Genesis.Engine;
using Nocturne.Genesis.Prompts;
using Nocturne.Genesis.Services;
using Nocturne.Genesis.Services.Lineage;
using Nocturne.Genesis.Assemblers;
using Nocturne.Surface;

namespace Nocturne.Genesis.Factories
{
    public sealed class GenesisFactory : IGenesisFactory
    {
        private readonly GenesisConfig _config;

        public GenesisFactory(string configPath = "genesis.config.json")
        {
            _config = GenesisConfigLoader.Load(configPath);

            _config.Llm.ApiKey = Env.Expand(_config.Llm.ApiKey);

            if (string.IsNullOrWhiteSpace(_config.Llm.ApiKey))
                throw new InvalidOperationException("LLM API key is missing. Check your environment variables.");
        }

        public IGenesisEngine Create(ISurfaceArtifact seed, IGenesisOptions? options = null)
        {
            var mergedOfflineMode =
                options?.OfflineMode ?? _config.Defaults.OfflineMode;

            var mergedPromptSetPath =
                options?.PromptSetPath ?? _config.Defaults.PromptSetPath;

            var mergedLocalizationPath =
                options?.LocalizationPath ?? _config.Defaults.LocalizationPath;

            // Prompt assets
            var promptSet = PromptSetLoader.Load(mergedPromptSetPath);
            var localization = PromptLocalizationLoader.Load(mergedLocalizationPath);
            var promptBuilder = new LlmPromptBuilder();

            // LLM client + world adapter
            var llmClient = new GeminiLlmClientBuilder()
                .UseHttpClient(new HttpClient())
                .UseEndpoint(_config.Llm.Endpoint)
                .UseApiKey(_config.Llm.ApiKey)
                .UseModel(_config.Llm.Model)
                .Build();

            IGenesisWorldLlmAdapter llm = new GeminiLlmAdapter(llmClient);

            // Prompt service
            var promptService = new GenesisPromptService(
                promptSet,
                localization,
                promptBuilder,
                llm,
                mergedOfflineMode
            );

            // Lineage services
            var provenanceService = new ProvenanceService();
            var versioningService = new VersioningService();
            var fingerprintService = new FingerprintService();

            // Inference service
            var inference = new GenesisInferenceService(llm);

            // Assemblers
            var domainAssembler = new DomainAssembler();
            var conceptAssembler = new ConceptAssembler();
            var cardAssembler = new CardAssembler();
            var starterDeckAssembler = new StarterDeckAssembler();
            var presentationAssembler = new PresentationAssembler();

            // Transitional concept service (wraps DTO → IConcept)
            var conceptService = new GenesisConceptService();

            // Surface writer
            var surfaceWriter = new SurfaceWriter();

            // Builder
            var builder = new GenesisBuilder(
                inference,
                fingerprintService,
                domainAssembler,
                conceptAssembler,
                cardAssembler,
                starterDeckAssembler,
                presentationAssembler,
                surfaceWriter
            );

            // Riffing service
            var riffService = new RiffService(
                new ApprovalService(
                    versioningService,
                    provenanceService,
                    fingerprintService
                )
            );


            // Engine (updated signature — concept service removed)
            return new GenesisEngine(
                seed,
                promptService,
                inference,
                builder,
                provenanceService,
                versioningService,
                fingerprintService,
                conceptService,
                riffService
            );
        }
    }
}