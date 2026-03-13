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

            // Assemble concept artifacts
            var conceptAssembler = new ConceptAssembler();
            var conceptArtifacts = conceptAssembler.Assemble(
                conceptLlm,
                ArtifactIdentity.ShortId("concept"),
                context.Logger
            );

            // Convert each domain into a DomainDefinition
            var domainDefinitions = new List<DomainDefinition>();

            foreach (var domainLlm in domainsLlm)
            {
                var domainId  = ArtifactIdentity.ShortId("domain");
                var domainSlug = ArtifactIdentity.Slugify(domainLlm.DomainName ?? "domain");

                domainDefinitions.Add(new DomainDefinition
                {
                    Id         = domainId,
                    Slug       = domainSlug,
                    DomainName = domainLlm.DomainName ?? "domain",
                    Summary    = domainLlm.Summary ?? "",
                    Tags       = domainLlm.Tags?.ToList() ?? new(),
                    Timestamp  = DateTime.UtcNow
                });
            }

            // Presentation definition
            var presentationId  = ArtifactIdentity.ShortId("presentation");
            var presSlug        = ArtifactIdentity.Slugify(presentationLlm.Title ?? "presentation");

            var presentation = new PresentationDefinition
            {
                Id        = presentationId,
                Slug      = presSlug,
                Title     = presentationLlm.Title ?? "",
                Summary   = presentationLlm.Summary ?? "",
                Layout    = presentationLlm.Layout ?? "default",
                Style     = presentationLlm.Style ?? "standard",
                Tags      = presentationLlm.Tags?.ToList() ?? new(),
                Timestamp = DateTime.UtcNow
            };

            // Build unified DTO (no cards, no starter deck)
            var unified = new UnifiedWorldPackageDto
            {
                Domains      = domainDefinitions,
                Concept      = conceptArtifacts,
                Cards        = new List<CardDefinition>(),   // always empty
                StarterDeck  = null,                         // always null
                Presentation = presentation
            };

            // Write world package
            var assembler = new UnifiedWorldPackageAssembler(rootPath);
            assembler.Assemble(JsonSerializer.Serialize(unified));

            return new SurfaceDTO
            {
                WorldId   = seed.Id,
                WorldName = seed.Name,
                Version   = 1
            };
        }
    }
}