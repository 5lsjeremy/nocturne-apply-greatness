using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.WorldPackageSchema.SurfaceDTO;
using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;
using Nocturne.Genesis.Assemblers;
using Nocturne.Surface;
using Nocturne.Surface.Diagnostics;
using Nocturne.Surface.IO;

namespace Nocturne.Genesis.Builders
{
    internal sealed class GenesisBuilder : IGenesisBuilder
    {
        private readonly IGenesisInferenceService _inference;
        private readonly IFingerprintService _fingerprints;
        private readonly DomainAssembler _domainAssembler;
        private readonly ConceptAssembler _conceptAssembler;
        private readonly CardAssembler _cardAssembler;
        private readonly StarterDeckAssembler _starterDeckAssembler;
        private readonly PresentationAssembler _presentationAssembler;
        private readonly SurfaceWriter _surfaceWriter;

        public GenesisBuilder(
            IGenesisInferenceService inference,
            IFingerprintService fingerprints,
            DomainAssembler domainAssembler,
            ConceptAssembler conceptAssembler,
            CardAssembler cardAssembler,
            StarterDeckAssembler starterDeckAssembler,
            PresentationAssembler presentationAssembler,
            SurfaceWriter surfaceWriter)
        {
            _inference = inference;
            _fingerprints = fingerprints;
            _domainAssembler = domainAssembler;
            _conceptAssembler = conceptAssembler;
            _cardAssembler = cardAssembler;
            _starterDeckAssembler = starterDeckAssembler;
            _presentationAssembler = presentationAssembler;
            _surfaceWriter = surfaceWriter;
        }

        public async Task<SurfaceDTO> BuildWorldAsync(
            string rootPath,
            ISurfaceArtifact seed,
            IGenesisContext context,
            string inferenceRunId,
            IOverlayTags? tags,
            LlmWorldPackageResponse world,
            CancellationToken ct = default)
        {
            // world is already provided by the engine — do NOT call inference again
            var domainLlm       = world.Domain       ?? new LlmDomainResponse();
            var conceptLlm      = world.Concept      ?? new LlmConceptResponse();
            var cardLlm         = world.Card         ?? new LlmCardResponse();
            var deckLlm         = world.StarterDeck  ?? new LlmStarterDeckResponse();
            var presentationLlm = world.Presentation ?? new LlmPresentationResponse();

            // IDs
            var domainId       = domainLlm.DomainName ?? seed.Id;
            var conceptId      = conceptLlm.SeedId ?? seed.Id;
            var cardId         = Guid.NewGuid().ToString("N");
            var deckId         = Guid.NewGuid().ToString("N");
            var presentationId = Guid.NewGuid().ToString("N");

            // Fingerprints
            var domainFp       = _fingerprints.ComputeFingerprint(domainLlm);
            var conceptFp      = _fingerprints.ComputeFingerprint(conceptLlm);
            var cardFp         = _fingerprints.ComputeFingerprint(cardLlm);
            var deckFp         = _fingerprints.ComputeFingerprint(deckLlm);
            var presentationFp = _fingerprints.ComputeFingerprint(presentationLlm);

            // Loggers
            var domainLogger       = new SurfaceLogger();
            var conceptLogger      = new SurfaceLogger();
            var cardLogger         = new SurfaceLogger();
            var deckLogger         = new SurfaceLogger();
            var presentationLogger = new SurfaceLogger();

            //
            // 1. Assemble the card FIRST (needed by domain)
            //
            var cardArtifacts = _cardAssembler.Assemble(
                cardLlm,
                cardId,
                cardFp,
                version: 1,
                origin: "inference",
                logger: cardLogger
            );

            //
            // 2. DomainAssembler now requires cards
            //
            var domainArtifacts = _domainAssembler.Assemble(
                domainLlm,
                domainId,
                new[] { cardArtifacts },   // NEW: pass cards into domain
                domainLogger
            );

            //
            // 3. Concept, StarterDeck, Presentation unchanged
            //
            var conceptArtifacts = _conceptAssembler.Assemble(
                conceptLlm,
                conceptId,
                conceptLogger
            );

            var deckArtifacts = _starterDeckAssembler.Assemble(
                deckLlm,
                deckId,
                deckFp,
                version: 1,
                origin: "inference",
                deckLogger
            );

            var presentationArtifacts = _presentationAssembler.Assemble(
                presentationLlm,
                presentationId,
                presentationFp,
                version: 1,
                origin: "inference",
                presentationLogger
            );

            //
            // 4. Overlay metadata (optional)
            //
            if (tags != null)
            {
                deckArtifacts.Definition.Tags.Add($"tone:{tags.Tone}");
                deckArtifacts.Definition.Tags.Add($"density:{tags.Density}");
                deckArtifacts.Definition.Tags.Add($"risk:{tags.Risk}");
            }

            //
            // 5. Write world package
            //
            return _surfaceWriter.WriteWorldPackage(
                rootPath,
                worldId: seed.Id,
                worldName: seed.Name,
                version: 1,
                domains: new[] { domainArtifacts },
                concepts: new[] { conceptArtifacts },
                cards: new[] { cardArtifacts },
                starterDecks: new[] { deckArtifacts },
                presentations: new[] { presentationArtifacts }
            );
        }
    }
}