using Nocturne.Abstractions.Genesis.Lineage;

namespace Nocturne.Genesis.Models.Lineage
{
    public class DeckLineage : IDeckLineage
    {
        public string SeedId { get; init; }
        public string InferenceRunId { get; init; }
        public IReadOnlyList<string> CardIds { get; init; }
        public IReadOnlyList<int> CardVersionNumbers { get; init; }
        public string MetadataFingerprint { get; init; }
        public string DeckFingerprint { get; init; }
    }
}