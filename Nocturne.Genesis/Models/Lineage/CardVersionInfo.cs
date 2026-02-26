using Nocturne.Abstractions.Genesis.Lineage;

namespace Nocturne.Genesis.Models.Lineage
{
    public class CardVersionInfo : IVersionInfo
    {
        public int VersionNumber { get; init; }
        public DateTime Timestamp { get; init; }
        public string Author { get; init; }
        public string Origin { get; init; }
        public string Status { get; init; }
        public string ReviewState { get; init; }
        public string Confidence { get; init; }
        public string Intent { get; init; }
        public string Notes { get; init; }
        public string Fingerprint { get; init; }
    }
}