namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainRuleSet
    {
        IEnumerable<IDomainProtectionRule> ProtectionRules { get; }
        IEnumerable<IDomainReinforcementRule> ReinforcementRules { get; }
    }
}