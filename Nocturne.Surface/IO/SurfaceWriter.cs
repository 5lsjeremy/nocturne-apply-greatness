using System.Text.Json;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.SurfaceDTO;
using Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO;
using Nocturne.Abstractions.WorldPackageSchema.SparksDTO;

namespace Nocturne.Surface.IO
{
    public sealed class SurfaceWriter
    {
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = null
        };

        public SurfaceDTO WriteWorldPackage(
            string rootPath,
            string worldId,
            string worldName,
            int version,
            IEnumerable<DomainArtifactsDTO> domains,
            IEnumerable<ConceptArtifactsDTO> concepts,
            IEnumerable<CardArtifactsDTO> cards,
            IEnumerable<StarterDeckArtifactsDTO> starterDecks,
            IEnumerable<PresentationArtifactsDTO> presentations,
            IEnumerable<SparkArtifact>? sparks = null)
        {
            //
            // 1. Create temporary build directory
            //
            var tmp = Path.Combine(rootPath, "_tmp_build");
            if (Directory.Exists(tmp))
                Directory.Delete(tmp, recursive: true);

            Directory.CreateDirectory(tmp);

            //
            // 2. Create subfolders
            //
            var domainsPath       = Path.Combine(tmp, "Domains");
            var conceptsPath      = Path.Combine(tmp, "Concepts");
            var cardsPath         = Path.Combine(tmp, "Cards");
            var sparksPath        = Path.Combine(tmp, "Sparks");
            var starterDecksPath  = Path.Combine(tmp, "StarterDecks");
            var presentationPath  = Path.Combine(tmp, "Presentation");

            Directory.CreateDirectory(domainsPath);
            Directory.CreateDirectory(conceptsPath);
            Directory.CreateDirectory(cardsPath);
            Directory.CreateDirectory(sparksPath);
            Directory.CreateDirectory(starterDecksPath);
            Directory.CreateDirectory(presentationPath);

            //
            // 3. Write artifacts
            //
            var domainIds       = WriteArtifacts(domainsPath, domains);
            var conceptIds      = WriteArtifacts(conceptsPath, concepts);
            var cardIds         = WriteArtifacts(cardsPath, cards);
            var starterDeckIds  = WriteArtifacts(starterDecksPath, starterDecks);
            var presentationIds = WriteArtifacts(presentationPath, presentations);

            // Sparks are optional (Genesis produces none, Lens produces many)
            var sparkIds = sparks != null
                ? WriteArtifacts(sparksPath, sparks)
                : new List<string>();

            //
            // 4. Write indexes
            //

            // Domain → Cards
            var domainCardIndex = domains.ToDictionary(
                d => d.Definition.DomainName,
                d => d.Cards.Select(c => c.Definition.CardId).ToList()
            );
            File.WriteAllText(
                Path.Combine(domainsPath, "card-index.json"),
                JsonSerializer.Serialize(domainCardIndex, _jsonOptions)
            );

            // Card → Sparks
            var cardSparkIndex = cards.ToDictionary<CardArtifactsDTO, string, List<string>>(
                    c => c.Definition.CardId,
                    c => c.Sparks
                        .Select<SparkDTO, string>(s => s.Id)
                        .ToList()
            );
            File.WriteAllText(
                Path.Combine(cardsPath, "spark-index.json"),
                JsonSerializer.Serialize(cardSparkIndex, _jsonOptions)
            );

            //
            // 5. Validate structure before committing
            //
            Validate(domainIds, conceptIds, cardIds, starterDeckIds, presentationIds);

            //
            // 6. Build SurfaceDTO
            //
            var surface = new SurfaceDTO
            {
                WorldId = worldId,
                WorldName = worldName,
                Version = version,
                Timestamp = DateTime.UtcNow,

                DomainIds = domainIds,
                ConceptIds = conceptIds,
                CardIds = cardIds,
                StarterDeckIds = starterDeckIds,
                PresentationIds = presentationIds,

                HasDomains = domainIds.Any(),
                HasConcepts = conceptIds.Any(),
                HasCards = cardIds.Any(),
                HasStarterDecks = starterDeckIds.Any(),
                HasPresentations = presentationIds.Any(),

                DomainsPath = "Domains",
                ConceptsPath = "Concepts",
                CardsPath = "Cards",
                StarterDecksPath = "StarterDecks",
                PresentationPath = "Presentation"
            };

            //
            // 7. Write manifest
            //
            var surfacePath = Path.Combine(tmp, "surface.json");
            File.WriteAllText(surfacePath, JsonSerializer.Serialize(surface, _jsonOptions));

            //
            // 8. Commit atomically
            //
            var finalPath = Path.Combine(rootPath, "WorldPackage");
            if (Directory.Exists(finalPath))
                Directory.Delete(finalPath, recursive: true);

            Directory.Move(tmp, finalPath);

            return surface;
        }

        private List<string> WriteArtifacts<T>(string folder, IEnumerable<T> artifacts)
        {
            var ids = new List<string>();

            foreach (var artifact in artifacts)
            {
                var id = ExtractId(artifact);
                ids.Add(id);

                var path = Path.Combine(folder, $"{id}.json");
                File.WriteAllText(path, JsonSerializer.Serialize(artifact, _jsonOptions));
            }

            return ids;
        }

        private static string ExtractId<T>(T artifact)
        {
            return artifact switch
            {
                DomainArtifactsDTO d       => d.Definition.DomainName,
                ConceptArtifactsDTO c      => c.Core.SeedId,
                CardArtifactsDTO card      => card.Definition.CardId,
                StarterDeckArtifactsDTO sd => sd.Definition.DeckId,
                PresentationArtifactsDTO p => p.Definition.PresentationId,
                SparkArtifact spark        => spark.Definition.Id,
                _ => throw new InvalidOperationException("Unknown artifact type")
            };
        }

        private static void Validate(
            List<string> domains,
            List<string> concepts,
            List<string> cards,
            List<string> starterDecks,
            List<string> presentations)
        {
            if (domains.Any(string.IsNullOrWhiteSpace))
                throw new InvalidOperationException("Domain ID missing.");

            if (concepts.Any(string.IsNullOrWhiteSpace))
                throw new InvalidOperationException("Concept ID missing.");

            if (cards.Any(string.IsNullOrWhiteSpace))
                throw new InvalidOperationException("Card ID missing.");

            if (starterDecks.Any(string.IsNullOrWhiteSpace))
                throw new InvalidOperationException("Starter deck ID missing.");

            if (presentations.Any(string.IsNullOrWhiteSpace))
                throw new InvalidOperationException("Presentation ID missing.");
        }
    }
}