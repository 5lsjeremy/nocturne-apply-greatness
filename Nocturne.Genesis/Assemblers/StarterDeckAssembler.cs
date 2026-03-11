using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Genesis.Utilities;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Assemblers
{
    public sealed class StarterDeckAssembler
    {
        public StarterDeckArtifactsDTO Assemble(
            LlmStarterDeckResponse llm,
            string deckId,
            string fingerprint,
            int version,
            string origin,
            SurfaceLogger logger)
        {
            var defTemplate = TemplateLoader.LoadTemplate<StarterDeckDefinition>("StarterDecks/deck.json");
            var metaTemplate = TemplateLoader.LoadTemplate<StarterDeckMetadata>("StarterDecks/metadata.json");
            var logsTemplate = TemplateLoader.LoadTemplate<StarterDeckLogs>("StarterDecks/logs.json");

            var definition = defTemplate with
            {
                DeckId = deckId,
                Title = llm.Title,
                Summary = llm.Summary,
                CardIds = llm.CardIds.ToList(),
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
                    .Select(e => new StarterDeckLogEntry
                    {
                        Timestamp = e.Timestamp,
                        DeckId = deckId,
                        Message = e.Message,
                        Category = e.Category,
                        Source = e.Source,
                        Version = version
                    })
                    .ToList()
            };

            return new StarterDeckArtifactsDTO(definition, metadata, logs);
        }
    }
}