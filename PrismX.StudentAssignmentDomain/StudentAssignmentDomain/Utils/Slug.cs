using System.Text.RegularExpressions;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils;

public static class Slug
{
    public static string Create(string id, string name)
    {
        if (string.IsNullOrWhiteSpace(id) && string.IsNullOrWhiteSpace(name))
            return string.Empty;

        string baseText = $"{id}-{name}".Trim().ToLowerInvariant();

        // Replace whitespace with hyphens
        baseText = Regex.Replace(baseText, @"\s+", "-");

        // Remove invalid characters
        baseText = Regex.Replace(baseText, @"[^a-z0-9\-]", "");

        return baseText;
    }

    /// <summary>
    /// Reconstructs a SkillUnit from a slug created by Slug.Create(id, name).
    /// </summary>
    public static SkillUnit BuildSkillUnitFromSlug(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            return new SkillUnit();

        // Split into: [unitId] - [slugified name]
        var parts = slug.Split('-', 2);

        if (parts.Length < 2)
            return new SkillUnit { UnitId = slug };

        var unitId = parts[0];
        var unitNameSlug = parts[1];

        // Convert slugified name back into a readable name
        var unitName = unitNameSlug.Replace('-', ' ');

        return new SkillUnit
        {
            UnitId = unitId,
            UnitName = unitName // This automatically regenerates UnitSlug
        };
    }
}