using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Genesis.Models;

namespace Nocturne.Genesis.Engine
{
    internal sealed class GenesisEngine : IGenesisEngine
    {
        private readonly ISurfaceArtifact _seed;
        private readonly IGenesisBuilder _builder;
        private readonly IGenesisInferenceService _inference;
        private readonly IGenesisPromptService _prompts;

        // NEW: lineage services injected
        private readonly IProvenanceService _provenanceService;
        private readonly IVersioningService _versioningService;
        private readonly IFingerprintService _fingerprintService;

        public GenesisEngine(
            ISurfaceArtifact seed,
            IGenesisBuilder builder,
            IGenesisInferenceService inference,
            IGenesisPromptService prompts,
            IProvenanceService provenanceService,
            IVersioningService versioningService,
            IFingerprintService fingerprintService)
        {
            _seed = seed;
            _builder = builder;
            _inference = inference;
            _prompts = prompts;

            _provenanceService = provenanceService;
            _versioningService = versioningService;
            _fingerprintService = fingerprintService;
        }

        public IStarterDeck Generate()
        {
            // 1. Build context from seed
            var context = new GenesisContext(_seed);

            // 2. Run prompt loop
            _prompts.RunMvpLoop(context);

            // 3. Run inference
            var inference = _inference.Infer(context);

            // 4. Create a unique inference run ID
            var inferenceRunId = Guid.NewGuid().ToString("N");

            // 5. Attach lineage to each card
            foreach (var card in inference.Cards)
            {
                var promptAnswers = context.Answers
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.ToString() ?? string.Empty
                    );

                var provenance = _provenanceService.CreateProvenance(
                    seedId: _seed.Id,
                    promptAnswers: promptAnswers,
                    llm: new[] { "inference" },
                    builder: Array.Empty<string>(),
                    rules: new[] { "initial-inference" }
                );

                var version = _versioningService.CreateInitialVersion(
                    author: "system",
                    origin: "inference",
                    artifact: card
                );

                var fingerprint = _fingerprintService.ComputeFingerprint(card);

                card.Provenance = provenance;
                ((GenesisCard)card).Versions.Add(version);
                card.Fingerprint = fingerprint;
            }

            // 6. Build deck with lineage preserved
            return _builder.BuildStarterDeck(
                _seed,
                context,
                inference,
                inferenceRunId
            );
        }
    }
}