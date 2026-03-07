using System.Text.RegularExpressions;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts;

internal static class RuleDescriptionInterpreter
{
    public static IDomainProtectionRule InterpretProtection(string description)
    {
        description = description.ToLowerInvariant();

        // Pattern: "reduce X pressure by Y%"
        var reduceMatch = Regex.Match(description, @"reduce\s+(\w+)\s+pressure\s+by\s+(\d+)%");
        if (reduceMatch.Success)
        {
            var type = ParsePressureType(reduceMatch.Groups[1].Value);
            var percent = float.Parse(reduceMatch.Groups[2].Value) / 100f;

            return new ConditionalProtectionRule(
                appliesToType: type,
                modifier: (m, _, _) => m * (1f - percent)
            );
        }

        // Pattern: "ignore X pressure"
        var ignoreMatch = Regex.Match(description, @"ignore\s+(\w+)\s+pressure");
        if (ignoreMatch.Success)
        {
            var type = ParsePressureType(ignoreMatch.Groups[1].Value);

            return new ConditionalProtectionRule(
                appliesToType: type,
                modifier: (m, _, _) => 0f
            );
        }

        // Fallback: basic rule
        return new BasicProtectionRule();
    }

    public static IDomainReinforcementRule InterpretReinforcement(string description)
    {
        description = description.ToLowerInvariant();

        // Pattern: "boost X sparks by Y%"
        var boostMatch = Regex.Match(description, @"boost\s+(\w+)\s+sparks?\s+by\s+(\d+)%");
        if (boostMatch.Success)
        {
            var type = ParseSparkType(boostMatch.Groups[1].Value);
            var percent = float.Parse(boostMatch.Groups[2].Value) / 100f;

            return new ConditionalReinforcementRule(
                appliesToType: type,
                modifier: (m, _, _) => m * (1f + percent)
            );
        }

        // Pattern: "double X sparks"
        var doubleMatch = Regex.Match(description, @"double\s+(\w+)\s+sparks?");
        if (doubleMatch.Success)
        {
            var type = ParseSparkType(doubleMatch.Groups[1].Value);

            return new ConditionalReinforcementRule(
                appliesToType: type,
                modifier: (m, _, _) => m * 2f
            );
        }

        // Fallback: basic rule
        return new BasicReinforcementRule();
    }

    private static PressureType ParsePressureType(string raw)
    {
        return Enum.TryParse<PressureType>(raw, true, out var result)
            ? result
            : PressureType.Generic;
    }

    private static SparkType ParseSparkType(string raw)
    {
        return Enum.TryParse<SparkType>(raw, true, out var result)
            ? result
            : SparkType.Generic;
    }
}