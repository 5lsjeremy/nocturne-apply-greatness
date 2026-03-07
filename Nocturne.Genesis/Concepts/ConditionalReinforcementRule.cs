using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts;

internal sealed class ConditionalReinforcementRule : IDomainReinforcementRule
{
    private readonly SparkType _appliesToType;
    private readonly Func<float, SparkType, IReadOnlyList<string>, float> _modifier;

    public ConditionalReinforcementRule(
        SparkType appliesToType,
        Func<float, SparkType, IReadOnlyList<string>, float> modifier)
    {
        _appliesToType = appliesToType;
        _modifier = modifier;
    }

    public bool AppliesTo(SparkType type, IReadOnlyList<string> tags)
        => type == _appliesToType;

    public float ModifyIncomingReinforcement(float magnitude, SparkType type, IReadOnlyList<string> tags)
        => _modifier(magnitude, type, tags);
}