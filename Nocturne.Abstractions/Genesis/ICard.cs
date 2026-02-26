using Nocturne.Abstractions.Genesis.Enums;
using Nocturne.Abstractions.Genesis.Lineage;

namespace Nocturne.Abstractions.Genesis
{
    public interface ICard
    {
        // Identity
        string Id { get; }
        string Name { get; }

        // Metadata
        IReadOnlyList<string> Tags { get; }
        IReadOnlyDictionary<string, object> Properties { get; }

        // Classification
        CardStatusDetails.CardType Type { get; }
        CardStatusDetails.CardOriginType Origin { get; }
        CardStatusDetails.CardStatusType Status { get; }
        CardStatusDetails.CardReviewState ReviewState { get; }
        CardStatusDetails.CardVisibility Visibility { get; }
        CardStatusDetails.CardIntentType Intent { get; }
        CardStatusDetails.CardAuthorityType Authority { get; }
        CardStatusDetails.CardConfidenceLevel Confidence { get; }
        CardStatusDetails.CardScopeType Scope { get; }
        CardStatusDetails.CardStabilityType Stability { get; }
        CardStatusDetails.CardEnergyType Energy { get; }
        CardStatusDetails.CardComplexityLevel Complexity { get; }
        CardStatusDetails.CardDependencyRole DependencyRole { get; }

        // Lineage (NEW)

        /// <summary>
        /// The provenance record describing how this card was created:
        /// seed → prompts → inference → builder. Enables deterministic
        /// regeneration and full replay of the artifact chain.
        /// </summary>
        IProvenance Provenance { get; set; }

        /// <summary>
        /// The immutable version history of this card. Each version captures
        /// a snapshot of content, metadata, and fingerprint at a point in time.
        /// </summary>
        IReadOnlyList<IVersionInfo> Versions { get; }

        /// <summary>
        /// A deterministic fingerprint representing the card's current state.
        /// Used for conflict detection, merging, and replay validation.
        /// </summary>
        string Fingerprint { get; set; }
    }
}