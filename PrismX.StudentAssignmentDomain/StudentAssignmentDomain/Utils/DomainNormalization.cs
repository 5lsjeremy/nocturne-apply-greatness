namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils;

public static class DomainNormalization
{
    public static string NormalizeCognitive(string raw)
    {
        return raw?
            .Replace("cognitive-", "")
            .Trim()
            .ToLowerInvariant() ?? "unknown";
    }

    public static string NormalizeAffective(string raw)
    {
        return raw?
            .Replace("affective-", "")
            .Trim()
            .ToLowerInvariant() ?? "neutral";
    }

    public static string NormalizeDifficulty(string raw)
    {
        return raw?
            .Replace("difficulty-", "")
            .Trim()
            .ToLowerInvariant() ?? "medium";
    }

    public static string NormalizeMisconception(string raw)
    {
        return raw?
            .Replace("misconception-", "")
            .Trim()
            .ToLowerInvariant() ?? "none";
    }
}