using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Genesis.Utilities;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Assemblers
{
    public sealed class DomainAssembler
    {
        private readonly IFingerprintService _fingerprints;

        public DomainAssembler(IFingerprintService fingerprints)
        {
            _fingerprints = fingerprints;
        }

        public DomainArtifactsDTO Assemble(
            LlmDomainResponse llm,
            string domainId,
            IReadOnlyList<CardArtifactsDTO> cards,
            ISurfaceLogger logger)
        {
            // Load templates
            var definitionTemplate  = TemplateLoader.LoadTemplate<DomainDefinition>("Domains/domain.json");
            var clarityTemplate     = TemplateLoader.LoadTemplate<DomainClarity>("Domains/clarity.json");
            var feasibilityTemplate = TemplateLoader.LoadTemplate<DomainFeasibility>("Domains/feasibility.json");
            var metadataTemplate    = TemplateLoader.LoadTemplate<DomainMetadata>("Domains/metadata.json");
            var logsTemplate        = TemplateLoader.LoadTemplate<DomainLogs>("Domains/logs.json");

            // Generate slug
            var slug = ArtifactIdentity.Slugify(llm.DomainName ?? "domain");

            // -------------------------
            // Definition (LLM-driven)
            // -------------------------
            var definition = definitionTemplate with
            {
                Id                = domainId,
                Slug              = slug,
                DomainName        = llm.DomainName,
                Summary           = llm.Summary,
                Boundaries        = llm.Boundaries.ToList(),
                Tone              = llm.Tone,
                Tags              = llm.Tags.ToList(),
                Opportunities     = llm.Opportunities.ToList(),
                Risks             = llm.Risks.ToList(),
                DriftWarnings     = llm.DriftWarnings.ToList(),
                PressureTestSeeds = llm.PressureTestSeeds.ToList(),
                PrismSeeds        = llm.PrismSeeds.ToList(),
                Timestamp         = DateTime.UtcNow
            };

            // -------------------------
            // Clarity (template-driven)
            // -------------------------
            var clarity = clarityTemplate with
            {
                Timestamp = DateTime.UtcNow
            };

            // -------------------------
            // Feasibility (template-driven)
            // -------------------------
            var feasibility = feasibilityTemplate with
            {
                Timestamp = DateTime.UtcNow
            };

            // -------------------------
            // Metadata (fingerprint + lineage)
            // -------------------------
            var fingerprint = _fingerprints.ComputeFingerprint(llm);

            var metadata = metadataTemplate with
            {
                DomainId    = domainId,
                Fingerprint = fingerprint,
                Version     = 1,
                Origin      = "genesis",
                Timestamp   = DateTime.UtcNow
            };

            // -------------------------
            // Logs
            // -------------------------
            var logs = logsTemplate with
            {
                Entries = logger.Entries
                    .Select(e => new DomainLogEntry
                    {
                        Timestamp = e.Timestamp,
                        Domain    = domainId,
                        Message   = e.Message,
                        Source    = e.Source,
                        Version   = 1
                    })
                    .ToList()
            };

            // -------------------------
            // Final artifact bundle
            // -------------------------
            return new DomainArtifactsDTO(
                definition,
                cards,
                clarity,
                feasibility,
                metadata,
                logs
            );
        }
    }
}