using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts;

internal static class RuleSetAssembler
{
    public static IDomainRuleSet Assemble(IDomainSeed seed)
    {
        var protectionRules = new List<IDomainProtectionRule>();
        var reinforcementRules = new List<IDomainReinforcementRule>();

        // Interpret protection rule descriptions
        if (seed.ProtectionRules != null)
        {
            foreach (var desc in seed.ProtectionRules)
                protectionRules.Add(RuleDescriptionInterpreter.InterpretProtection(desc));
        }

        // Interpret reinforcement rule descriptions
        if (seed.ReinforcementRules != null)
        {
            foreach (var desc in seed.ReinforcementRules)
                reinforcementRules.Add(RuleDescriptionInterpreter.InterpretReinforcement(desc));
        }

        // Fallback defaults if none provided
        if (protectionRules.Count == 0)
            protectionRules.Add(new BasicProtectionRule());

        if (reinforcementRules.Count == 0)
            reinforcementRules.Add(new BasicReinforcementRule());

        // Build the rule set
        return new DomainRuleSet
        {
            Domain = seed.Name,

            // Correct handling of nullable floats
            DefaultThreshold = seed.DefaultThreshold ?? 100f,
            DefaultGravity = seed.DefaultGravity ?? 0.5f,

            ProtectionRules = protectionRules,
            ReinforcementRules = reinforcementRules,
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