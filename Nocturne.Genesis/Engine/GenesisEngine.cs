using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Genesis.Models;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Engine
{
    internal sealed class GenesisEngine : IGenesisEngine
    {
        private readonly ISurfaceArtifact _seed;
        private readonly IGenesisBuilder _builder;
        private readonly IConceptService _concepts;
        private readonly IProvenanceService _provenanceService;
        private readonly IVersioningService _versioningService;
        private readonly IFingerprintService _fingerprintService;
        private readonly IRiffService _riffService;

        public GenesisEngine(
            ISurfaceArtifact seed,
            IGenesisBuilder builder,
            IConceptService concepts,
            IProvenanceService provenanceService,
            IVersioningService versioningService,
            IFingerprintService fingerprintService,
            IRiffService riffService)
        {
            _seed = seed;
            _builder = builder;
            _concepts = concepts;
            _provenanceService = provenanceService;
            _versioningService = versioningService;
            _fingerprintService = fingerprintService;
            _riffService = riffService;
        }

        public async Task<IGenesisSession> GenerateAsync(IOverlayTags? tags = null)
        {
            //
            // 1. Generate the concept DTO in one LLM call
            //
            var concept = await _concepts.EvaluateAsync(_seed.WorldConcept);

            //
            // 2. Create a fresh context for the builder
            //
            var context = new GenesisContext(
                seed: _seed,
                concept: concept,
                cards: new List<ICard>(),
                answers: new Dictionary<string, object?>(),
                overlayTags: tags
            );

            //
            // 3. Build the world (builder owns inference, provenance, fingerprints)
            //
            var inferenceRunId = Guid.NewGuid().ToString("N");
            var rootPath = _seed.Id;

            var world = await _builder.BuildWorldAsync(
                rootPath: rootPath,
                seed: _seed,
                context: context,
                inferenceRunId: inferenceRunId,
                tags: tags
            );

            //
            // 4. Engine-level provenance/versioning/fingerprints for cards
            //
            foreach (var card in context.Cards)
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

            //
            // 5. Return session
            //
            return new GenesisSession
            {
                Concept = concept,
                SeedId = _seed.Id,
                Timestamp = DateTime.UtcNow,
                World = world,
                Cards = context.Cards.ToList(),
                StarterDeck = default!, // SurfaceDTO does not contain a deck
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