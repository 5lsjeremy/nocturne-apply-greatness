namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils
{
    public static class AffectiveDimensionMapper
    {
        public static string Map(StudentAnalyzeInput input)
        {
            var response = input.StudentResponse.ToLowerInvariant();

            string dimension =
                response.Contains("i don't understand") ||
                response.Contains("confused") ||
                response.Contains("lost")
                    ? "confusion"
                    : response.Contains("i think") ||
                      response.Contains("i believe") ||
                      response.Contains("i'm sure")
                        ? "confidence"
                        : response.Contains("this is hard") ||
                          response.Contains("difficult") ||
                          response.Contains("frustrating")
                            ? "frustration"
                            : "neutral";

            return Slug.Create("affective", dimension);
        }
    }
}