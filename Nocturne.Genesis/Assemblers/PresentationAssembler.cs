using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;
using Nocturne.Genesis.Utilities;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Assemblers
{
    public sealed class PresentationAssembler
    {
        public PresentationArtifactsDTO Assemble(
            LlmPresentationResponse llm,
            string presentationId,
            string fingerprint,
            int version,
            string origin,
            ISurfaceLogger logger)
        {
            var defTemplate = TemplateLoader.LoadTemplate<PresentationDefinition>("Presentation/presentation.json");
            var metaTemplate = TemplateLoader.LoadTemplate<PresentationMetadata>("Presentation/metadata.json");
            var logsTemplate = TemplateLoader.LoadTemplate<PresentationLogs>("Presentation/logs.json");

            var definition = defTemplate with
            {
                Id = presentationId,
                Slug = ArtifactIdentity.Slugify(llm.Title ?? presentationId),
                Title = llm.Title ?? string.Empty,
                Subtitle = llm.Subtitle ?? string.Empty,
                Overview = llm.Overview ?? string.Empty,
                Pillars = llm.Pillars?.ToList() ?? new List<string>(),
                RecommendedNextSteps = llm.RecommendedNextSteps?.ToList() ?? new List<string>(),
                Timestamp = DateTime.UtcNow
            };

            var metadata = metaTemplate with
            {
                Origin = origin,
                Fingerprint = fingerprint,
                Version = version,
                Timestamp = DateTime.UtcNow
            };

            var logs = logsTemplate with
            {
                Entries = logger.Entries
                    .Select(e => new PresentationLogEntry
                    {
                        Timestamp = e.Timestamp,
                        PresentationId = presentationId,
                        Message = e.Message,
                        Category = e.Category,
                        Source = e.Source,
                        Version = version
                    })
                    .ToList()
            };

            return new PresentationArtifactsDTO(definition, metadata, logs);
        }
    }
}