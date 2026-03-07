using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts;

internal sealed class BasicProtectionRule : IDomainProtectionRule
{
    public bool AppliesTo(PressureType type, IReadOnlyList<string> tags)
        => true; // applies to all pressures by default

    public float ModifyIncomingPressure(float magnitude, PressureType type, IReadOnlyList<string> tags)
        => magnitude * 0.9f; // 10% resistance
}