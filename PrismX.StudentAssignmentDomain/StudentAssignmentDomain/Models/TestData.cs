namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models
{
    public static class TestData
    {
        public static StudentProfile BuildStudentProfile()
        {
            return new StudentProfile
            {
                Subjects =
                {
                    ["history"] = new SkillSubject
                    {
                        SubjectId = "history",
                        SubjectName = "History",
                        Courses =
                        {
                            ["civilwar"] = new SkillCourse
                            {
                                CourseId = "civilwar",
                                CourseName = "Civil War",
                                Units =
                                {
                                    ["causes"] = new SkillUnit
                                    {
                                        UnitId = "causes",
                                        UnitName = "Causes of the Civil War",
                                        Score = 0f
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}