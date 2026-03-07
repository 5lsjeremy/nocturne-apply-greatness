using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainReinforcementRule
    {
        bool AppliesTo(SparkType type, IReadOnlyList<string> tags);
        float ModifyIncomingReinforcement(float magnitude, SparkType type, IReadOnlyList<string> tags);
    }
}