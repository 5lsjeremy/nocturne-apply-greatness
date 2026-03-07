using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts;

internal static class DomainRuleSetFactory
{
    public static IDomainRuleSet CreateDefault(string domainName)
    {
        return new DomainRuleSet
        {
            Domain = domainName,
            DefaultThreshold = 100f,
            DefaultGravity = 0.5f,
            ProtectionRules = new List<IDomainProtectionRule>
            {
                new BasicProtectionRule()
            },
            ReinforcementRules = new List<IDomainReinforcementRule>
            {
                new BasicReinforcementRule()
            },
            CollapseEvaluator = BasicCollapseEvaluator
        };
    }

    private static bool BasicCollapseEvaluator(IDomainValue value, IWorldContext world)
    {
        if (value.Current <= 0)
            return true;

        if (world.Flags.HasFlag(WorldFlags.CollapseImminent))
            return true;

        return false;
    }
}