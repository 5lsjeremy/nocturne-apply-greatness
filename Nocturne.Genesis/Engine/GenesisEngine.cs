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

        private readonly IProvenanceService _provenanceService;
        private readonly IVersioningService _versioningService;
        private readonly IFingerprintService _fingerprintService;

        // NEW for Step 5
        private readonly IRiffService _riff;

        public GenesisEngine(
            ISurfaceArtifact seed,
            IGenesisBuilder builder,
            IGenesisInferenceService inference,
            IGenesisPromptService prompts,
            IProvenanceService provenanceService,
            IVersioningService versioningService,
            IFingerprintService fingerprintService,
            IRiffService riff)
        {
            _seed = seed;
            _builder = builder;
            _inference = inference;
            _prompts = prompts;

            _provenanceService = provenanceService;
            _versioningService = versioningService;
            _fingerprintService = fingerprintService;

            _riff = riff;
        }

        public IGenesisSession Generate()
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
                var concrete = (GenesisCard)card;

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

                concrete.Provenance = provenance;
                concrete.Versions.Add(version);
                concrete.Fingerprint = fingerprint;
            }

            // 6. Build deck with lineage preserved
            var deck = _builder.BuildStarterDeck(
                _seed,
                context,
                inference,
                inferenceRunId
            );

            // 7. Wrap everything in a session (Step 5)
            return new GenesisSession
            {
                SeedId = _seed.Id,
                Timestamp = DateTime.UtcNow,
                Cards = inference.Cards,
                StarterDeck = deck
            };
        }

        public ICard Riff(ICard card, string contributor, string prompt)
        {
            return _riff.Riff(card, contributor, prompt);
        }
    }
}