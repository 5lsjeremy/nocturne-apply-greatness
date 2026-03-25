using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Overlays;
using Nocturne.Genesis.Models;
using Nocturne.Genesis.Services;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Engine
{
    internal sealed class GenesisEngine : IGenesisEngine
    {
        private readonly ISurfaceArtifact _seed;
        private readonly IGenesisBuilder _builder;
        private readonly IGenesisInferenceService _inference;
        private readonly IProvenanceService _provenanceService;
        private readonly IVersioningService _versioningService;
        private readonly IFingerprintService _fingerprintService;
        private readonly IRiffService _riffService;

        public GenesisEngine(
            ISurfaceArtifact seed,
            IGenesisBuilder builder,
            IGenesisInferenceService inference,
            IProvenanceService provenanceService,
            IVersioningService versioningService,
            IFingerprintService fingerprintService,
            IRiffService riffService)
        {
            _seed = seed;
            _builder = builder;
            _inference = inference;
            _provenanceService = provenanceService;
            _versioningService = versioningService;
            _fingerprintService = fingerprintService;
            _riffService = riffService;
        }

        public async Task<IGenesisSession> GenerateAsync(IOverlayTags? tags = null)
        {
            // 1. Create logger for this run
            var logger = new SurfaceLogger();

            // 2. Create context (concept will be filled after inference)
            var context = new GenesisContext(
                seed: _seed,
                concept: null!,                     // filled after inference
                cards: new List<ICard>(),
                answers: new Dictionary<string, object?>(),
                overlayTags: tags,
                logger: logger                      // <-- FIXED
            );

            // 3. Unified world-package inference
            var inferenceRunId = Guid.NewGuid().ToString("N");
            var worldPackage = await _inference.GenerateWorldPackageAsync(context, tags);

            // 4. Update context with concept from unified response
            context.Concept = new ConceptFromDto(worldPackage.Concept);

            // 5. Build world artifacts using unified DTO
            var rootPath = _seed.Id;
            var builtWorld = await _builder.BuildWorldAsync(
                rootPath: rootPath,
                seed: _seed,
                context: context,
                inferenceRunId: inferenceRunId,
                tags: tags,
                world: worldPackage
            );

            // 6. Engine-level provenance/versioning/fingerprints for cards
            foreach (var card in context.Cards)
            {
                var concrete = (GenesisCard)card;

                var promptAnswers = context.Answers.ToDictionary(
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

            // 7. Return session
            return new GenesisSession
            {
                Concept = new ConceptFromDto(worldPackage.Concept),
                SeedId = _seed.Id,
                Timestamp = DateTime.UtcNow,
                World = builtWorld,
                Cards = context.Cards.ToList(),
                StarterDeck = new StarterDeckFromDto(worldPackage.StarterDeck),
                InferenceRunId = inferenceRunId,
                PromptAnswers = context.Answers.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.ToString() ?? string.Empty
                ),
            };
        }

        public ICard Riff(ICard card, string contributor, string prompt)
        {
            return _riffService.Riff(card, contributor, prompt);
        }
    }
}