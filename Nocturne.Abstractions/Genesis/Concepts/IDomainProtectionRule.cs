using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainProtectionRule
    {
        bool AppliesTo(PressureType type, IReadOnlyList<string> tags);
        float ModifyIncomingPressure(float magnitude, PressureType type, IReadOnlyList<string> tags);
    }
}