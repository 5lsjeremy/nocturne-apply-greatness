using Nocturne.Abstractions.Genesis.Enums;

namespace Nocturne.Abstractions.Genesis
{
    public interface ICard
    {
        string Id { get; }
        string Name { get; }
        IReadOnlyList<string> Tags { get; }
        IReadOnlyDictionary<string, object> Properties { get; }

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
    }
}