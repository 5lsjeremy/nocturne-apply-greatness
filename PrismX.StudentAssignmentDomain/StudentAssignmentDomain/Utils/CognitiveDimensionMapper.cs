namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils
{
    public static class CognitiveDimensionMapper
    {
        public static string Map(StudentAnalyzeInput input)
        {
            var text = input.AssignmentText.ToLowerInvariant();

            string dimension =
                // CREATE
                text.Contains("design") ||
                text.Contains("develop") ||
                text.Contains("construct") ||
                text.Contains("compose") ||
                text.Contains("formulate")
                    ? "create"

                    // EVALUATE
                    : text.Contains("evaluate") ||
                      text.Contains("justify") ||
                      text.Contains("critique") ||
                      text.Contains("argue")
                        ? "evaluate"

                        // ANALYZE
                        : text.Contains("analyze") ||
                          text.Contains("compare") ||
                          text.Contains("contrast") ||
                          text.Contains("differentiate")
                            ? "analyze"

                            // APPLY
                            : text.Contains("apply") ||
                              text.Contains("solve") ||
                              text.Contains("use")
                                ? "apply"

                                // UNDERSTAND
                                : text.Contains("explain") ||
                                  text.Contains("summarize") ||
                                  text.Contains("describe") ||
                                  text.Contains("interpret")
                                    ? "understand"

                                    // REMEMBER
                                    : "remember";

            return Slug.Create("cognitive", dimension);
        }
    }
}