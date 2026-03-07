using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts;

internal sealed class TravelIntegrityRuleSet : IDomainRuleSet
{
    public string Domain => "TravelIntegrity";

    public IReadOnlyList<IDomainProtectionRule> ProtectionRules { get; }
        = new[] { new BasicProtectionRule() };

    public IReadOnlyList<IDomainReinforcementRule> ReinforcementRules { get; }
        = new[] { new BasicReinforcementRule() };

    public float DefaultThreshold => 100f;
    public float DefaultGravity => 0.5f;

    public bool CheckCollapse(IDomainValue value, IWorldContext world)
        => BasicCollapseRule.Check(value, world);
}