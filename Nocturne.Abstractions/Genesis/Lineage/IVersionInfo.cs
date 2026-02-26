namespace Nocturne.Abstractions.Genesis.Lineage
{
    /// <summary>
    /// Represents a single point in the artifact's version chain.
    /// Versions are immutable snapshots that allow draft → publish → replay.
    /// </summary>
    public interface IVersionInfo
    {
        int VersionNumber { get; }
        DateTime Timestamp { get; }
        string Author { get; }
        string Origin { get; }
        string Status { get; }
        string ReviewState { get; }
        string Confidence { get; }
        string Intent { get; }
        string Notes { get; }
        string Fingerprint { get; }
    }
}