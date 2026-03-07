using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts;

internal sealed class BasicReinforcementRule : IDomainReinforcementRule
{
    public bool AppliesTo(SparkType type, IReadOnlyList<string> tags)
        => true; // applies to all sparks by default

    public float ModifyIncomingReinforcement(float magnitude, SparkType type, IReadOnlyList<string> tags)
        => magnitude * 1.1f; // 10% bonus
}