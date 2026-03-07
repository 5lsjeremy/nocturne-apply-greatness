using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts;

internal sealed class ConditionalProtectionRule : IDomainProtectionRule
{
    private readonly PressureType _appliesToType;
    private readonly Func<float, PressureType, IReadOnlyList<string>, float> _modifier;

    public ConditionalProtectionRule(
        PressureType appliesToType,
        Func<float, PressureType, IReadOnlyList<string>, float> modifier)
    {
        _appliesToType = appliesToType;
        _modifier = modifier;
    }

    public bool AppliesTo(PressureType type, IReadOnlyList<string> tags)
        => type == _appliesToType;

    public float ModifyIncomingPressure(float magnitude, PressureType type, IReadOnlyList<string> tags)
        => _modifier(magnitude, type, tags);
}