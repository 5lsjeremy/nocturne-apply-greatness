namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

public sealed class LessonDefinition
{
    public string AssignmentText { get; set; } = string.Empty;

    // NEW: the unit this lesson is tied to
    public string UnitSlug { get; set; } = string.Empty;
}