using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.SurfaceDTO
{
    public sealed record SurfaceDTO
    {
        [JsonPropertyName("worldId")]
        public string WorldId { get; init; } = string.Empty;

        [JsonPropertyName("worldName")]
        public string WorldName { get; init; } = string.Empty;

        [JsonPropertyName("version")]
        public int Version { get; init; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        // --- Artifact Registries (IDs only) ---

        [JsonPropertyName("domainIds")]
        public List<string> DomainIds { get; init; } = new();

        [JsonPropertyName("conceptIds")]
        public List<string> ConceptIds { get; init; } = new();

        [JsonPropertyName("cardIds")]
        public List<string> CardIds { get; init; } = new();

        [JsonPropertyName("starterDeckIds")]
        public List<string> StarterDeckIds { get; init; } = new();

        [JsonPropertyName("presentationIds")]
        public List<string> PresentationIds { get; init; } = new();

        // --- Presence Flags ---

        [JsonPropertyName("hasDomains")]
        public bool HasDomains { get; init; }

        [JsonPropertyName("hasConcepts")]
        public bool HasConcepts { get; init; }

        [JsonPropertyName("hasCards")]
        public bool HasCards { get; init; }

        [JsonPropertyName("hasStarterDecks")]
        public bool HasStarterDecks { get; init; }

        [JsonPropertyName("hasPresentations")]
        public bool HasPresentations { get; init; }

        // --- File Paths (relative to world package root) ---

        [JsonPropertyName("domainsPath")]
        public string DomainsPath { get; init; } = "Domains";

        [JsonPropertyName("conceptsPath")]
        public string ConceptsPath { get; init; } = "Concepts";

        [JsonPropertyName("cardsPath")]
        public string CardsPath { get; init; } = "Cards";

        [JsonPropertyName("starterDecksPath")]
        public string StarterDecksPath { get; init; } = "StarterDecks";

        [JsonPropertyName("presentationPath")]
        public string PresentationPath { get; init; } = "Presentation";
    }
}