using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Adapters;
using Nocturne.Genesis.Builders;
using Nocturne.Genesis.Config;
using Nocturne.Genesis.Engine;
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
            //
            // 1. Low-level LLM client
            //
            var llmClient = new GeminiLlmClientBuilder()
                .UseHttpClient(new HttpClient())
                .UseEndpoint(_config.Llm.Endpoint)
                .UseApiKey(_config.Llm.ApiKey)
                .UseModel(_config.Llm.Model)
                .Build();

            //
            // 2. Unified world inference adapter
            //
            var llmAdapter = new GeminiLlmAdapter(llmClient);
            var inference = new GenesisInferenceService(llmAdapter);

            //
            // 3. Lineage services
            //
            var provenanceService = new ProvenanceService();
            var versioningService = new VersioningService();
            var fingerprintService = new FingerprintService();

            //
            // 4. Assemblers
            //
            var domainAssembler = new DomainAssembler();
            var conceptAssembler = new ConceptAssembler();
            var cardAssembler = new CardAssembler();
            var starterDeckAssembler = new StarterDeckAssembler();
            var presentationAssembler = new PresentationAssembler();

            //
            // 5. Surface writer
            //
            var surfaceWriter = new SurfaceWriter();

            //
            // 6. Builder (now takes inference + assemblers)
            //
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

            //
            // 7. Riffing service
            //
            var riffService = new RiffService(
                new ApprovalService(
                    versioningService,
                    provenanceService,
                    fingerprintService
                )
            );

            //
            // 8. Engine (new signature)
            //
            return new GenesisEngine(
                seed,
                builder,
                inference,            // ✔️ correct replacement for conceptService
                provenanceService,
                versioningService,
                fingerprintService,
                riffService
            );
        }
    }
}