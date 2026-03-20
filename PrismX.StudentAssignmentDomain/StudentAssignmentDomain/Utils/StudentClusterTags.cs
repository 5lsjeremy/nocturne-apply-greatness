namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils
{
    public static class StudentClusterTags
    {
        public static IReadOnlyList<string> Extract(StudentAnalyzeInput input)
        {
            var tags = new List<string>
            {
                $"unit:{input.UnitSlug}",

                // Assignment slug now uses ID + Name
                $"assignment:{Slug.Create(
                    id: "assignment",
                    name: input.AssignmentText
                )}",

                "skill:analysis",
                "domain:student"
            };

            if (!string.IsNullOrWhiteSpace(input.StudentResponse))
            {
                tags.Add($"response:{Slug.Create(
                    id: "response",
                    name: input.StudentResponse
                )}");
            }

            return tags;
        }
    }
}