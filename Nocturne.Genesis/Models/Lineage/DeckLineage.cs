using Nocturne.Abstractions.Genesis.Lineage;

namespace Nocturne.Genesis.Models.Lineage
{
    public sealed class DeckLineage : IDeckLineage
    {
        public string SeedId { get; init; }
        public string InferenceRunId { get; init; }
        public IReadOnlyList<string> CardIds { get; init; }
        public IReadOnlyList<int> CardVersionNumbers { get; init; }
        public string MetadataFingerprint { get; init; }
        public string DeckFingerprint { get; init; }

        // ✅ Non-null, reusable empty instance
        public static IDeckLineage Empty { get; } = new DeckLineage
        {
            SeedId = string.Empty,
            InferenceRunId = string.Empty,
            CardIds = Array.Empty<string>(),
            CardVersionNumbers = Array.Empty<int>(),
            MetadataFingerprint = string.Empty,
            DeckFingerprint = string.Empty
        };
    }
}