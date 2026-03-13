using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Adapters;
using Nocturne.Genesis.Builders;
using Nocturne.Genesis.Config;
using Nocturne.Genesis.Engine;
using Nocturne.Genesis.Services;
using Nocturne.Genesis.Services.Lineage;
using Nocturne.Surface.IO;

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
            // 1. LLM client
            var llmClient = new DeepSeekLlmClientBuilder()
                .UseHttpClient(new HttpClient { Timeout = TimeSpan.FromSeconds(300) })
                .UseEndpoint(_config.Llm.Endpoint)
                .UseApiKey(_config.Llm.ApiKey)
                .UseScaffoldModel(_config.Llm.ScaffoldModel)
                .UseRefineModel(_config.Llm.RefineModel)
                .UseSynthesisModel(_config.Llm.SynthesisModel)
                .UsePremiumModel(_config.Llm.PremiumModel)
                .Build();

            // 2. Inference adapter + service
            var llmAdapter = new DeepSeekLlmAdapter(llmClient);
            var inference = new GenesisInferenceService(llmAdapter);

            // 3. Lineage services
            var provenanceService = new ProvenanceService();
            var versioningService = new VersioningService();
            var fingerprintService = new FingerprintService();

            // 4. Surface writer
            var surfaceWriter = new SurfaceWriter();

            // 5. Builder (new signature)
            var builder = new GenesisBuilder(
                inference,
                fingerprintService,
                surfaceWriter
            );

            // 6. Riffing service
            var riffService = new RiffService(
                new ApprovalService(
                    versioningService,
                    provenanceService,
                    fingerprintService
                )
            );

            // 7. Engine
            return new GenesisEngine(
                seed,
                builder,
                inference,
                provenanceService,
                versioningService,
                fingerprintService,
                riffService
            );
        }
    }
}