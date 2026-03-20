namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils
{
    public static class DifficultyEstimator
    {
        public static string Estimate(string assignmentText)
        {
            var text = assignmentText.ToLowerInvariant();

            if (text.Contains("evaluate") ||
                text.Contains("justify") ||
                text.Contains("argue"))
                return Slug.Create("difficulty", "high");

            if (text.Contains("explain") ||
                text.Contains("analyze") ||
                text.Contains("compare"))
                return Slug.Create("difficulty", "medium");

            return Slug.Create("difficulty", "low");
        }
    }
}