using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts;

internal sealed class DomainRuleSet : IDomainRuleSet
{
    public string Domain { get; init; } = "";

    public IReadOnlyList<IDomainProtectionRule> ProtectionRules { get; init; }
        = Array.Empty<IDomainProtectionRule>();

    public IReadOnlyList<IDomainReinforcementRule> ReinforcementRules { get; init; }
        = Array.Empty<IDomainReinforcementRule>();

    public float DefaultThreshold { get; init; }
    public float DefaultGravity { get; init; }

    public Func<IDomainValue, IWorldContext, bool> CollapseEvaluator { get; init; }
        = (_, _) => false;

    public bool CheckCollapse(IDomainValue value, IWorldContext world)
        => CollapseEvaluator(value, world);
}