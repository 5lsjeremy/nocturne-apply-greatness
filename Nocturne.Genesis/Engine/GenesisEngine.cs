using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts.Enums;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Overlays;
using Nocturne.Genesis.Concepts;
using Nocturne.Genesis.Models;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Engine
{
    internal sealed class GenesisEngine : IGenesisEngine
    {
        private readonly ISurfaceArtifact _seed;
        private readonly IGenesisPromptService _prompts;
        private readonly IGenesisInferenceService _inference;   // currently unused, but kept for signature parity
        private readonly IGenesisBuilder _builder;
        private readonly IProvenanceService _provenanceService;
        private readonly IVersioningService _versioningService;
        private readonly IFingerprintService _fingerprintService;
        private readonly IConceptService _concepts;
        private readonly IRiffService _riffService;

        public GenesisEngine(
            ISurfaceArtifact seed,
            IGenesisPromptService prompts,
            IGenesisInferenceService inference,
            IGenesisBuilder builder,
            IProvenanceService provenanceService,
            IVersioningService versioningService,
            IFingerprintService fingerprintService,
            IConceptService concepts,
            IRiffService riffService)
        {
            _seed = seed;
            _prompts = prompts;
            _inference = inference;
            _builder = builder;
            _provenanceService = provenanceService;
            _versioningService = versioningService;
            _fingerprintService = fingerprintService;
            _concepts = concepts;
            _riffService = riffService;
        }

        public async Task<IGenesisSession> GenerateAsync(IOverlayTags? tags = null)
        {
            //
            // 1. Evaluate concept (old concept pipeline still in play)
            //
            var concept = await _concepts.EvaluateAsync(_seed.WorldConcept);

            // 1a. Log feasibility outcome with LLM metadata (unchanged)
            {
                var eval = concept.Evaluation;
                var meta = concept.Metadata;

                var message = eval.IsFeasible
                    ? "Concept feasibility check passed."
                    : $"Concept feasibility check failed: {eval.FailureReason ?? "Unknown reason"}";

                var entry = new SurfaceLogEntry(
                    eval.IsFeasible ? SurfaceLogLevel.Info : SurfaceLogLevel.Error,
                    message,
                    "genesis.concept-evaluator",
                    new Dictionary<string, object?>
                    {
                        ["llm.raw"] = meta.RawResponse,
                        ["llm.parsed"] = meta.ParsedResponseJson,
                        ["llm.interpretation"] = meta.PipelineInterpretation
                    }
                );

                (concept.Metadata as ConceptMetadata)?.AddLog(entry);
            }

            //
            // 2. Thread concept into context
            //
            var context = new GenesisContext(
                seed: _seed,
                concept: concept,
                cards: new List<ICard>(),
                answers: new Dictionary<string, object?>(),
                overlayTags: tags
            );

            //
            // 3. MVP loop (prompt enrichment)
            //
            await _prompts.RunMvpLoopAsync(context, tags);

            //
            // 4. Inference + world build are now owned by the builder
            //    Builder will use IGenesisInferenceService internally via its constructor.
            //
            var inferenceRunId = Guid.NewGuid().ToString("N");

            // You can choose a root path strategy; for now, use the seed ID as a stable root.
            var rootPath = _seed.Id;

            var world = await _builder.BuildWorldAsync(
                rootPath: rootPath,
                seed: _seed,
                context: context,
                inferenceRunId: inferenceRunId,
                tags: tags
            );

            //
            // 5. (Optional) Provenance/versioning/fingerprint at engine level
            //    If the builder now owns this, you can remove this block entirely.
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
            // 6. Return session
            //
            return new GenesisSession
            {
                Concept = concept,
                SeedId = _seed.Id,
                Timestamp = DateTime.UtcNow,
                Cards = context.Cards.ToList(),   // fixes IList → IReadOnlyList
                StarterDeck = default!,           // SurfaceDTO does NOT contain a deck
                InferenceRunId = inferenceRunId,
                PromptAnswers = context.Answers.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.ToString() ?? string.Empty
                )
            };
        }

        public ICard Riff(ICard card, string contributor, string prompt)
        {
            return _riffService.Riff(card, contributor, prompt);
        }
    }
}