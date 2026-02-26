namespace Nocturne.Abstractions.Genesis.Lineage
{
    /// <summary>
    /// Describes the lineage of a deck: its seed, inference run, card set, and fingerprints.
    /// Deck lineage enables deterministic regeneration and expansion layering.
    /// </summary>
    public interface IDeckLineage
    {
        string SeedId { get; }
        string InferenceRunId { get; }
        IReadOnlyList<string> CardIds { get; }
        IReadOnlyList<int> CardVersionNumbers { get; }
        string MetadataFingerprint { get; }
        string DeckFingerprint { get; }
    }
}