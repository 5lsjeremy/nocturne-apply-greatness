using System.Text.Json;
using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts;

internal static class DomainSeedExtractor
{
    public static DomainSeed FromJson(JsonElement json)
    {
        return new DomainSeed
        {
            Name = GetString(json, "Name") ?? "",
            Summary = GetString(json, "Summary"),

            Vectors = GetStringList(json, "Vectors"),
            Stats = GetStringList(json, "Stats"),
            Behaviors = GetStringList(json, "Behaviors"),

            ProtectionRules = GetStringList(json, "ProtectionRules"),
            ReinforcementRules = GetStringList(json, "ReinforcementRules"),

            DefaultThreshold = GetNullableFloat(json, "DefaultThreshold"),
            DefaultGravity = GetNullableFloat(json, "DefaultGravity")
        };
    }

    private static string? GetString(JsonElement json, string name)
    {
        return json.TryGetProperty(name, out var prop) && prop.ValueKind == JsonValueKind.String
            ? prop.GetString()
            : null;
    }

    private static IReadOnlyList<string> GetStringList(JsonElement json, string name)
    {
        if (!json.TryGetProperty(name, out var prop) || prop.ValueKind != JsonValueKind.Array)
            return Array.Empty<string>();

        var list = new List<string>();
        foreach (var item in prop.EnumerateArray())
        {
            if (item.ValueKind == JsonValueKind.String)
                list.Add(item.GetString()!);
        }

        return list;
    }

    private static float? GetNullableFloat(JsonElement json, string name)
    {
        if (!json.TryGetProperty(name, out var prop))
            return null;

        if (prop.ValueKind == JsonValueKind.Number && prop.TryGetSingle(out var f))
            return f;

        return null;
    }
}