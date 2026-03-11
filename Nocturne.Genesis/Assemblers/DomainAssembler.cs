using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Genesis.Utilities;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Assemblers
{
    public sealed class DomainAssembler
    {
        public DomainArtifactsDTO Assemble(
            LlmDomainResponse llm,
            string domainId,
            SurfaceLogger logger)
        {
            // Load templates
            var definitionTemplate = TemplateLoader.LoadTemplate<DomainDefinition>("Domains/domain.json");
            var clarityTemplate = TemplateLoader.LoadTemplate<DomainClarity>("Domains/clarity.json");
            var feasibilityTemplate = TemplateLoader.LoadTemplate<DomainFeasibility>("Domains/feasibility.json");
            var logsTemplate = TemplateLoader.LoadTemplate<DomainLogs>("Domains/logs.json");

            // Fill definition (schema-correct)
            var definition = definitionTemplate with
            {
                DomainName = domainId,
                Summary = llm.Summary,
                Boundaries = llm.Boundaries.ToList(),
                Tone = llm.Tone,
                Tags = llm.Tags.ToList(),
                Opportunities = llm.Opportunities.ToList(),
                Risks = llm.Risks.ToList(),
                DriftWarnings = llm.DriftWarnings.ToList(),
                PressureTestSeeds = llm.PressureTestSeeds.ToList(),
                PrismSeeds = llm.PrismSeeds.ToList(),
                Timestamp = DateTime.UtcNow
            };

            // Fill clarity
            var clarity = clarityTemplate with
            {
                ClarityScore = llm.ClarityScore,
                Good = llm.Good,
                Bad = llm.Bad,
                Ugly = llm.Ugly,
                Notes = llm.ClarityNotes,
                Timestamp = DateTime.UtcNow
            };

            // Fill feasibility
            var feasibility = feasibilityTemplate with
            {
                CreativePotential = llm.CreativePotential,
                ProductionRisks = llm.ProductionRisks.ToList(),
                Opportunities = llm.OpportunitiesFeasibility.ToList(),
                Pitfalls = llm.Pitfalls.ToList(),
                AlignmentWithWorld = llm.AlignmentWithWorld,
                ExpectedComplexity = llm.ExpectedComplexity,
                RecommendedFocusAreas = llm.RecommendedFocusAreas.ToList(),
                Timestamp = DateTime.UtcNow
            };

            // Fill logs
            var logs = logsTemplate with
            {
                Entries = logger.Entries
                    .Select(e => new DomainLogEntry
                    {
                        Timestamp = e.Timestamp,
                        Domain = domainId,
                        Message = e.Message,
                        Source = e.Source,
                        Version = 1
                    })
                    .ToList()
            };

            return new DomainArtifactsDTO(definition, clarity, feasibility, logs);
        }
    }
}