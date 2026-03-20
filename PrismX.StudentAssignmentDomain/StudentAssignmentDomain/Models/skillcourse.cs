using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

public sealed class SkillCourse
{
    private string _courseName = string.Empty;

    public string CourseId { get; set; } = string.Empty;

    public string CourseName
    {
        get => _courseName;
        set
        {
            _courseName = value;
            CourseSlug = Slug.Create(CourseId, value);
        }
    }

    public string CourseSlug { get; private set; } = string.Empty;

    public Dictionary<string, SkillUnit> Units { get; set; } = new();
}