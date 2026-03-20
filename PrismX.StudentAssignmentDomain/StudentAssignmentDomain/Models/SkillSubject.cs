using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

public sealed class SkillSubject
{
    private string _subjectName = string.Empty;

    public string SubjectId { get; set; } = string.Empty;

    public string SubjectName
    {
        get => _subjectName;
        set
        {
            _subjectName = value;
            SubjectSlug = Slug.Create(SubjectId, value);
        }
    }

    public string SubjectSlug { get; private set; } = string.Empty;

    public Dictionary<string, SkillCourse> Courses { get; set; } = new();
}