using System.Text.RegularExpressions;

namespace Nocturne.Genesis.Config;

internal static class Env
{
    private static readonly Regex UnixPattern = new(@"\$\{(?<name>[A-Za-z0-9_]+)\}", RegexOptions.Compiled);
    private static readonly Regex BashPattern = new(@"\$(?<name>[A-Za-z0-9_]+)", RegexOptions.Compiled);

    public static string Expand(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return value;

        // Windows-style: %VAR%
        var expanded = Environment.ExpandEnvironmentVariables(value);

        // Unix-style: ${VAR}
        expanded = UnixPattern.Replace(expanded, match =>
        {
            var name = match.Groups["name"].Value;
            return Environment.GetEnvironmentVariable(name) ?? match.Value;
        });

        // Unix-style: $VAR
        expanded = BashPattern.Replace(expanded, match =>
        {
            var name = match.Groups["name"].Value;
            return Environment.GetEnvironmentVariable(name) ?? match.Value;
        });

        return expanded;
    }
}