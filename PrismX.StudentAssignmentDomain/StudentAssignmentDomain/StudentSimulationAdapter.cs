using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain;

public sealed class StudentSimulationAdapter
{
    public LessonDefinition Lesson { get; }
    public StudentProfile Profile { get; }
    public StudentState State { get; }

    public StudentSimulationAdapter(
        LessonDefinition lesson,
        StudentProfile profile,
        StudentState state)
    {
        Lesson = lesson;
        Profile = profile;
        State = state;
    }

    public StudentAnalyzeInput ToAnalyzeInput(string studentResponse)
    {
        return new StudentAnalyzeInput
        {
            AssignmentText = Lesson.AssignmentText,
            StudentResponse = studentResponse,
            UnitSlug = Lesson.UnitSlug
        };
    }
}