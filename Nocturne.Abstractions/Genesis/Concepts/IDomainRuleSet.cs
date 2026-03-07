namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainRuleSet
    {
        string Domain { get; }

        IReadOnlyList<IDomainProtectionRule> ProtectionRules { get; }
        IReadOnlyList<IDomainReinforcementRule> ReinforcementRules { get; }

        float DefaultThreshold { get; }
        float DefaultGravity { get; }

        bool CheckCollapse(IDomainValue value, IWorldContext world);
    }
}