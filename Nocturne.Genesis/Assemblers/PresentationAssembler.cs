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
            SurfaceLogger logger)
        {
            var defTemplate = TemplateLoader.LoadTemplate<PresentationDefinition>("Presentation/presentation.json");
            var metaTemplate = TemplateLoader.LoadTemplate<PresentationMetadata>("Presentation/metadata.json");
            var logsTemplate = TemplateLoader.LoadTemplate<PresentationLogs>("Presentation/logs.json");

            var definition = defTemplate with
            {
                Id = presentationId,
                Slug = ArtifactIdentity.Slugify(llm.Title),
                Title = llm.Title,
                Summary = llm.Summary,
                Layout = llm.Layout,
                Style = llm.Style,
                Tags = llm.Tags.ToList(),
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