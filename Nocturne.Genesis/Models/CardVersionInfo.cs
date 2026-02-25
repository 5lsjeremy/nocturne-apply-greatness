using Nocturne.Abstractions.Genesis.Enums;

namespace Nocturne.Genesis.Models
{
    internal sealed class CardVersionInfo
    {
        public int VersionNumber { get; set; }
        public DateTime Timestamp { get; set; }
        public string Author { get; set; }

        public CardStatusDetails.CardOriginType Origin { get; set; }
        public CardStatusDetails.CardStatusType Status { get; set; }
        public CardStatusDetails.CardReviewState ReviewState { get; set; }
        public CardStatusDetails.CardConfidenceLevel Confidence { get; set; }
        public CardStatusDetails.CardIntentType Intent { get; set; }

        public string Notes { get; set; }
    }
}