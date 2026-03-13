public static class ArtifactIdentity
{
    private static readonly char[] Alphabet =
        "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

    private static readonly Random Rng = new();

    public static string ShortId(string prefix, int length = 5)
    {
        var buffer = new char[length];
        for (int i = 0; i < length; i++)
            buffer[i] = Alphabet[Rng.Next(Alphabet.Length)];

        return $"{prefix}-{new string(buffer)}";
    }

    public static string Slugify(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return "untitled";

        var slug = title
            .Trim()
            .ToLowerInvariant()
            .Replace("'", "")
            .Replace("\"", "")
            .Replace(".", "")
            .Replace(",", "")
            .Replace(":", "")
            .Replace(";", "")
            .Replace("/", "-")
            .Replace("\\", "-");

        slug = System.Text.RegularExpressions.Regex
            .Replace(slug, @"[^a-z0-9]+", "-");

        slug = slug.Trim('-');

        return string.IsNullOrWhiteSpace(slug) ? "untitled" : slug;
    }
}