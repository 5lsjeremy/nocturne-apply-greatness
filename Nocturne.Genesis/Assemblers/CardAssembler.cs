using Nocturne.Abstractions.WorldPackageSchema;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.SparksDTO;
using Nocturne.Genesis.Utilities;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Assemblers
{
    public sealed class CardAssembler
    {
        public CardArtifactsDTO Assemble(
            LlmCardResponse llm,
            string cardId,
            string fingerprint,
            int version,
            string origin,
            SurfaceLogger logger)
        {
            // Load templates
            var definitionTemplate = TemplateLoader.LoadTemplate<CardDefinition>("Cards/card.json");
            var metadataTemplate   = TemplateLoader.LoadTemplate<CardMetadata>("Cards/metadata.json");
            var logsTemplate       = TemplateLoader.LoadTemplate<CardLogs>("Cards/logs.json");

            // Definition
            var definition = definitionTemplate with
            {
                CardId = cardId,
                Title = llm.Title,
                Summary = llm.Summary,
                Mechanics = llm.Mechanics.ToList(),
                Narrative = llm.Narrative,
                Tags = llm.Tags.ToList(),
                Timestamp = DateTime.UtcNow
            };

            // Metadata
            var metadata = metadataTemplate with
            {
                Author = "system",
                Origin = origin,
                Fingerprint = fingerprint,
                Version = version,
                Timestamp = DateTime.UtcNow
            };

            // Logs
            var logs = logsTemplate with
            {
                Entries = logger.Entries
                    .Select(e => new CardLogEntry
                    {
                        Timestamp = e.Timestamp,
                        CardId = cardId,
                        Message = e.Message,
                        Source = e.Source,
                        Version = version
                    })
                    .ToList()
            };

            // Sparks are discovered later by Lens → empty list here
            var sparks = Array.Empty<SparkDTO>();

            return new CardArtifactsDTO(definition, sparks, metadata, logs);
        }
    }
}