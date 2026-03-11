using Nocturne.Abstractions.Genesis;
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
            IOverlayTags? tags = null,
            CancellationToken ct = default)
        {
            // 1. Inference
            var domainLlm = await _inference.GenerateDomainAsync(context, tags, ct);
            var conceptLlm = await _inference.GenerateConceptAsync(context, tags, ct);
            var cardLlm = await _inference.GenerateCardAsync(context, tags, ct);
            var deckLlm = await _inference.GenerateStarterDeckAsync(context, tags, ct);
            var presentationLlm = await _inference.GeneratePresentationAsync(context, tags, ct);

            // 2. IDs
            var domainId = domainLlm.DomainName;
            var conceptId = conceptLlm.SeedId;
            var cardId = Guid.NewGuid().ToString("N");
            var deckId = Guid.NewGuid().ToString("N");
            var presentationId = Guid.NewGuid().ToString("N");

            // 3. Fingerprints
            var domainFp = _fingerprints.ComputeFingerprint(domainLlm);
            var conceptFp = _fingerprints.ComputeFingerprint(conceptLlm);
            var cardFp = _fingerprints.ComputeFingerprint(cardLlm);
            var deckFp = _fingerprints.ComputeFingerprint(deckLlm);
            var presentationFp = _fingerprints.ComputeFingerprint(presentationLlm);

            // 4. Loggers
            var domainLogger = new SurfaceLogger();
            var conceptLogger = new SurfaceLogger();
            var cardLogger = new SurfaceLogger();
            var deckLogger = new SurfaceLogger();
            var presentationLogger = new SurfaceLogger();
            
            // 5. Assemble artifacts

            var domainArtifacts = _domainAssembler.Assemble(
                domainLlm,
                domainId,
                domainLogger);

            var conceptArtifacts = _conceptAssembler.Assemble(
                conceptLlm,
                conceptId,
                conceptLogger);

            var cardArtifacts = _cardAssembler.Assemble(
                cardLlm,
                cardId,
                cardFp,
                1,
                "inference",
                cardLogger);

            var deckArtifacts = _starterDeckAssembler.Assemble(
                deckLlm,
                deckId,
                deckFp,
                1,
                "inference",
                deckLogger);

            var presentationArtifacts = _presentationAssembler.Assemble(
                presentationLlm,
                presentationId,
                presentationFp,
                1,
                "inference",
                presentationLogger);

            // 6. Overlay metadata (optional)
            if (tags != null)
            {
                deckArtifacts.Definition.Tags.Add($"tone:{tags.Tone}");
                deckArtifacts.Definition.Tags.Add($"density:{tags.Density}");
                deckArtifacts.Definition.Tags.Add($"risk:{tags.Risk}");
            }

            // 7. Write world package
            return _surfaceWriter.WriteWorldPackage(
                rootPath,
                worldId: seed.Id,
                worldName: seed.Name,
                version: 1,
                domains: new[] { domainArtifacts },
                concepts: new[] { conceptArtifacts },
                cards: new[] { cardArtifacts },
                starterDecks: new[] { deckArtifacts },
                presentations: new[] { presentationArtifacts });
        }
    }
}