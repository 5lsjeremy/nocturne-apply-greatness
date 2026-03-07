using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts;

internal sealed class FatigueRuleSet : IDomainRuleSet
{
    public string Domain => "Fatigue";

    public IReadOnlyList<IDomainProtectionRule> ProtectionRules { get; }
        = new[] { new BasicProtectionRule() };

    public IReadOnlyList<IDomainReinforcementRule> ReinforcementRules { get; }
        = new[] { new BasicReinforcementRule() };

    public float DefaultThreshold => 100f;
    public float DefaultGravity => 1.0f;

    public bool CheckCollapse(IDomainValue value, IWorldContext world)
        => BasicCollapseRule.Check(value, world);
}