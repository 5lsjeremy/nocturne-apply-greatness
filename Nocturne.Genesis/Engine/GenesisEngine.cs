using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Overlays;
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

        // NEW OVERLAY-AWARE GENERATE
        public async Task<IGenesisSession> GenerateAsync(IOverlayTags? tags = null)
        {
            var context = new GenesisContext(_seed, tags);

            await _prompts.RunMvpLoopAsync(context, tags);

            var inference = _inference.Infer(context, tags);

            var inferenceRunId = Guid.NewGuid().ToString("N");

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
                    llm: ["inference"],
                    builder: [],
                    rules: ["initial-inference"]
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

            var deck = _builder.BuildStarterDeck(
                _seed,
                context,
                inference,
                inferenceRunId,
                tags
            );

            return new GenesisSession
            {
                SeedId = _seed.Id,
                Timestamp = DateTime.UtcNow,
                Cards = inference.Cards,
                StarterDeck = deck,
                InferenceRunId = inferenceRunId,
                PromptAnswers = context.Answers.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.ToString() ?? string.Empty
                )
            };
        }

        public ICard Riff(ICard card, string contributor, string prompt)
            => _riff.Riff(card, contributor, prompt);
    }
}