using System.Text.Json;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.SurfaceDTO;
using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO;
using Nocturne.Genesis.Assemblers;
using Nocturne.Genesis.Utilities;
using Nocturne.Surface.IO;

namespace Nocturne.Genesis.Builders
{
    internal sealed class GenesisBuilder : IGenesisBuilder
    {
        private readonly IGenesisInferenceService _inference;
        private readonly IFingerprintService _fingerprints;
        private readonly SurfaceWriter _surfaceWriter;

        public GenesisBuilder(
            IGenesisInferenceService inference,
            IFingerprintService fingerprints,
            SurfaceWriter surfaceWriter)
        {
            _inference = inference;
            _fingerprints = fingerprints;
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
    // Extract LLM responses
    var domainsLlm      = world.Domains      ?? Array.Empty<LlmDomainResponse>();
    var conceptLlm      = world.Concept      ?? new LlmConceptResponse();
    var presentationLlm = world.Presentation ?? new LlmPresentationResponse();

    // -----------------------------
    // 1. Assemble Concept
    // -----------------------------
    var conceptAssembler = new ConceptAssembler();
    var conceptArtifacts = conceptAssembler.Assemble(
        conceptLlm,
        ArtifactIdentity.ShortId("concept"),
        context.Logger
    );

    // -----------------------------
    // 2. Assemble Domains
    // -----------------------------
    var domainAssembler = new DomainAssembler(_fingerprints);
    var domainArtifacts = new List<DomainArtifactsDTO>();

    foreach (var domainLlm in domainsLlm)
    {
        var domainId = ArtifactIdentity.ShortId("domain");

        var artifacts = domainAssembler.Assemble(
            domainLlm,
            domainId,
            new List<CardArtifactsDTO>(), // no cards yet
            context.Logger
        );

        domainArtifacts.Add(artifacts);
    }

    // -----------------------------
    // 3. Assemble Presentation
    // -----------------------------
    var presentationAssembler = new PresentationAssembler();
    var presentationId = ArtifactIdentity.ShortId("presentation");

    var presentationArtifacts = presentationAssembler.Assemble(
        presentationLlm,
        presentationId,
        fingerprint: _fingerprints.ComputeFingerprint(presentationLlm),
        version: 1,
        origin: "genesis",
        logger: context.Logger
    );

    // -----------------------------
    // 4. Write full artifact tree
    // -----------------------------
    var surface = _surfaceWriter.WriteWorldPackage(
        rootPath,
        seed.Id,
        seed.Name,
        version: 1,
        domains: domainArtifacts,
        concepts: new[] { conceptArtifacts },
        cards: Array.Empty<CardArtifactsDTO>(),
        starterDecks: Array.Empty<StarterDeckArtifactsDTO>(),
        presentations: new[] { presentationArtifacts }
    );

    // -----------------------------
    // 5. Build unified DTO
    // -----------------------------
    var unified = new UnifiedWorldPackageDto
    {
        Domains      = domainArtifacts.Select(d => d.Definition).ToList(),
        Concept      = conceptArtifacts,
        Cards        = new List<CardDefinition>(),
        StarterDeck  = null,
        Presentation = presentationArtifacts.Definition
    };

    // -----------------------------
    // 6. Write unified manifest
    // -----------------------------
    var unifiedAssembler = new UnifiedWorldPackageAssembler(rootPath);
    unifiedAssembler.Assemble(JsonSerializer.Serialize(unified));

    // -----------------------------
    // 7. Return SurfaceDTO
    // -----------------------------
    return surface;
}
    }
}